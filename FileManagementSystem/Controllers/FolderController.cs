using FileManagementSystemService;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    public class FolderController : Controller
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }
        [HttpPost("create-folder")]
        public IActionResult CreatFolder(string name, string? path)
        {
            var response = _folderService.CreatFolder(name,path);
            return Ok(response);
        }
        [HttpPost("create-sub-folder")]
        public IActionResult CreateSubFolders(string FolderName, string SubFolderName)
        {
            var response = _folderService.CreateSubFolders(FolderName, SubFolderName);
            return Ok(response);
        }
        [HttpGet("get-folder")]
        public IActionResult GetFolder(string? FolderName)
        {
            var response = _folderService.GetFolder(FolderName);
            return Ok(response);
        }
        [HttpPost("rename-folder")]
        public IActionResult RenameFolder(string FolderName, string FolderPath, string NewFolderName)
        {
            var response = _folderService.RenameFolder(FolderName, FolderPath, NewFolderName);
            return Ok(response);
        }
        [HttpDelete("delete-folder")]
        public IActionResult DeleteFolder(string FolderName, string? FolderPath)
        {
            var response = _folderService.DeleteFolder(FolderName, FolderPath);
            return Ok(response);
        }
    }
}
