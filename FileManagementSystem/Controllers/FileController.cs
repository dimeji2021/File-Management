using FileManagementSystemService;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult UploadFile(IFormFile file, string? FolderPath)
        {
            var response = _fileService.UploadFile(file, FolderPath);
            return Ok();
        }
    }
}
