using FileManagementSystemDomain.Dto_s;
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
        public IActionResult CreatFolder(CreateFolderDto model)
        {
            var response = _folderService.CreatFolder(model);
            return Ok(response);
        }
       
        [HttpGet("get-folder")]
        public IActionResult GetFolder(string path)
        {
            var response = _folderService.GetFolder(path);
            return Ok(response);
        }
        [HttpPatch("rename-folder")]
        public IActionResult RenameFolder(RenameFolderDto model)
        {
            var response = _folderService.RenameFolder(model);
            return Ok(response);
        }
        [HttpDelete("delete-folder")]
        public IActionResult DeleteFolder(string FolderPath)
        {
            var response = _folderService.DeleteFolder(FolderPath);
            return Ok(response);
        }
        [HttpGet("get-all-files-in-a-path")]
        public IActionResult GetAllFilesInAPath(string path)
        {
            var response = _folderService.GetAllFilesInAPath(path);
            return Ok(response);
        }
    }
}
