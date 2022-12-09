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
        public IActionResult CreatFolder(string name, string? path)
        {
            var response = _folderService.CreatFolder(name,path);
            return Ok(response);
        }
        public IActionResult CreateSubFolders(string FolderName, string SubFolderName)
        {
            var response = _folderService.CreatFolder(FolderName, SubFolderName);
            return Ok(response);
        }
        public IActionResult GetFolder(string? FolderName)
        {
            var response = _folderService.GetFolder(FolderName);
            return Ok(response);
        }
        public IActionResult RenameFolder(string FolderName, string FolderPath, string NewFolderName)
        {
            var response = _folderService.RenameFolder(FolderName, FolderPath, NewFolderName);
            return Ok(response);
        }
        public IActionResult DeleteFolder(string FolderName, string? FolderPath)
        {
            var response = _folderService.DeleteFolder(FolderName, FolderPath);
            return Ok(response);
        }
    }
}
