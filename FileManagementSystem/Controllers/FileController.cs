using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost("upload-file")]
        public IActionResult UploadFile(IFormFile file, string? FolderPath)
        {
            var response = _fileService.UploadFile(file, FolderPath);
            return Ok(response);
        }
        [HttpPost("create-file-inside-a-specific-folder")]
        public IActionResult CreateFilesByFolderName(string FolderName, string FileName)
        {
            var response = _fileService.CreateFilesByFolderName(FolderName, FileName);
            return Ok(response);
        }
        [HttpDelete("delete-file")]
        public IActionResult DeleteFiles(string filepath)
        {
            var response = _fileService.DeleteFiles(filepath);
            return Ok(response);
        }
        [HttpGet("get-all-file-in-a-specified-folder")]
        public IActionResult GetAllFilesByFolderName(string folderName)
        {
            var response = _fileService.GetAllFilesByFolderName(folderName);
            return Ok(response);
        }
        [HttpGet("get-file-content-in-a-specified-folder")]
        public IActionResult GetAllFileContentByFilePath(string filepath)
        {
            var response = _fileService.GetAllFileContentByFilePath(filepath);
            return Ok(response);
        }
        [HttpPut("update-file-content")]
        public IActionResult UpdateFileContent(string filepath, string newContent)
        {
            var response = _fileService.UpdateFileContent(filepath, newContent);
            return Ok(response);
        }
        [HttpPatch("rename-file")]
        public IActionResult RenameFile(string filepath, string newfileName)
        {
            var response = _fileService.RenameFile(filepath, newfileName);
            return Ok(response);
        }
        [HttpGet("read-file-content")]
        public IActionResult ReadFileContent(string filepath, string newContent)
        {
            var response = _fileService.ReadFileContent(filepath, newContent);
            return Ok(response);
        }
    }
}
