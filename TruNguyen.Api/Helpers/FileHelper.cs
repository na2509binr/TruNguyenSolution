using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace TruNguyen.Api.Helpers
{
    public static class FileHelper
    {
        public static string SlugFileName(string filename)
        {
            string name = Path.GetFileNameWithoutExtension(filename);
            string ext = Path.GetExtension(filename);

            // chuyển sang lowercase, bỏ dấu tiếng Việt
            name = RemoveDiacritics(name).ToLowerInvariant();

            // thay ký tự không phải chữ/số bằng "-"
            name = Regex.Replace(name, @"[^a-z0-9]+", "-").Trim('-');

            return $"{name}{ext}";
        }

        private static string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c == 'đ' || c == 'Đ' ? 'd' : c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }

}
