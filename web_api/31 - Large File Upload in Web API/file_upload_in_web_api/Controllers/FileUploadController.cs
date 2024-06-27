using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace file_upload_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath });
        }

        [HttpPost("uploadchunk")]
        public async Task<IActionResult> UploadChunk([FromForm] IFormFile chunk, [FromForm] string fileName, [FromForm] int chunkNumber)
        {
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var chunkPath = Path.Combine(uploadPath, $"{fileName}.part{chunkNumber}");

            using (var stream = new FileStream(chunkPath, FileMode.Create))
            {
                await chunk.CopyToAsync(stream);
            }

            return Ok();
        }

        [HttpPost("completeupload")]
        public IActionResult CompleteUpload([FromForm] string fileName, [FromForm] int totalChunks)
        {
            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            var finalPath = Path.Combine(_environment.WebRootPath, "uploads", $"{fileName}.final");

            using (var finalStream = new FileStream(finalPath, FileMode.Create))
            {
                for (int i = 0; i < totalChunks; i++)
                {
                    var chunkPath = Path.Combine(uploadPath, $"{fileName}.part{i}");
                    using (var chunkStream = new FileStream(chunkPath, FileMode.Open))
                    {
                        chunkStream.CopyTo(finalStream);
                    }

                    System.IO.File.Delete(chunkPath); // Remove chunk after merging
                }
            }

            Directory.Delete(uploadPath); // Remove the temporary directory

            return Ok(new { filePath = finalPath });
        }
    }
}
