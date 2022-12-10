using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FileManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerFileFolderController : ControllerBase
    {
        private IServerFileFolderService _serverFileFolderService;
        public ServerFileFolderController(IServerFileFolderService serverFileFolderService)
        {
            _serverFileFolderService = serverFileFolderService;
        }

        [SwaggerOperation(Summary = "This allows you create a folder in the current directory/assembly")]
        [HttpPost("create-directory")]
        public IActionResult Create(string parentFolder, string? childFolder)
        {
            if (childFolder is not null)
            {
                _serverFileFolderService.Create(parentFolder, childFolder);
            }
            else
            {
                _serverFileFolderService.Create(parentFolder);
            }
            return Ok();
        }
        [SwaggerOperation(Summary = "This allows you delete a file in a specified directory in the assembly")]
        [HttpDelete("delete-directory")]
        public IActionResult DeleteDirectory(string folder, string fileName)
        {
            var response = _serverFileFolderService.DeleteDirectory(folder, fileName);
            return Ok();
        }
        [SwaggerOperation(Summary = "This allows you upload a file to a directory")]
        [HttpPost("write-to-directory")]
        public IActionResult WriteDirectory(IFormFile request, string folder)
        {
            var response =_serverFileFolderService.WriteDirectory(request, folder);
            return Ok(response);
        }
    }
}
