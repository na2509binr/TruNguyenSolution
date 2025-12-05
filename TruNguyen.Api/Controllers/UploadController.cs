using Microsoft.AspNetCore.Mvc;
using TruNguyen.Api.Helpers;

namespace TruNguyen.Api.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string folderName)
        //{
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No file uploaded");

        //    var now = DateTime.Now;
        //    var year = now.Year;
        //    var month = now.Month.ToString("D2");
        //    var day = now.Day.ToString("D2");

        //    // Thư mục lưu file
        //    var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, year.ToString(), month, day);
        //    if (!Directory.Exists(dir))
        //        Directory.CreateDirectory(dir);

        //    // Chuẩn hóa tên file (bỏ dấu + slug)
        //    var fileName = FileHelper.SlugFileName(file.FileName);
        //    var fullPath = Path.Combine(dir, fileName);

        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    var relativePath = Path.Combine(folderName, year.ToString(), month, day, fileName).Replace("\\", "/");
        //    return Ok(new { filePath = relativePath });
        //}
    }

}
