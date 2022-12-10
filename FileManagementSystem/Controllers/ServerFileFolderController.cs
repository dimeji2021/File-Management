using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FileManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerOperation(Summary = "Signs in the user")]
    public class ServerFileFolderController : ControllerBase
    {
        private IServerFileFolderService _serverFileFolderService;
        public ServerFileFolderController(IServerFileFolderService serverFileFolderService)
        {
            _serverFileFolderService = serverFileFolderService;
        }

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
        [HttpDelete("delete-directory")]
        public IActionResult DeleteDirectory(string folder, string fileName)
        {
            var response = _serverFileFolderService.DeleteDirectory(folder, fileName);
            return Ok();
        }
        [HttpPost("write-to-directory")]
        public IActionResult WriteDirectory(IFormFile request, string folder)
        {
            var response =_serverFileFolderService.WriteDirectory(request, folder);
            return Ok(response);
        }
    }
}
