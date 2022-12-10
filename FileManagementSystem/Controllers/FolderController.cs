using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class FolderController : ControllerBase
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
       
        [HttpGet("get-folder")]
        public IActionResult GetFolder(string? FolderName)
        {
            var response = _folderService.GetFolder(FolderName);
            return Ok(response);
        }
        [HttpPost("rename-folder")]
        public IActionResult RenameFolder(string folderPath, string folder, string newFolder)
        {
            var response = _folderService.RenameFolder(folderPath, folder, newFolder);
            return Ok(response);
        }
        [HttpDelete("delete-folder")]
        public IActionResult DeleteFolder(string FolderPath)
        {
            var response = _folderService.DeleteFolder(FolderPath);
            return Ok(response);
        }
    }
}
