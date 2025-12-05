using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace TruNguyen.Api.Helpers
{
    public class FormatSlug
    {
        public static string ToSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase)) return "";

            // Thay đ/Đ trước
            string str = phrase.Replace("Đ", "D").Replace("đ", "d");

            // Chuẩn hoá Unicode về dạng tách dấu
            str = str.Normalize(NormalizationForm.FormD);

            // Loại bỏ dấu
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            str = sb.ToString();

            // Lowercase
            str = str.ToLowerInvariant();

            // Loại ký tự không hợp lệ
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // Trim, đổi khoảng trắng thành -, gom nhiều - thành 1
            str = Regex.Replace(str, @"\s+", "-").Trim();
            str = Regex.Replace(str, @"-+", "-");

            return str;
        }

    }
}
