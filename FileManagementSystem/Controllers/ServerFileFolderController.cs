using FileManagementSystemService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        Testing testing = new Testing();
        [HttpPost("create-directory")]
        public IActionResult Create(string parentFolder, string? childFolder)
        {
            if (childFolder is not null)
            {
                testing.Create(parentFolder, childFolder);
            }
            else
            {
                testing.Create(parentFolder);
            }
            return Ok();
        }
        [HttpDelete("delete-directory")]
        public IActionResult DeleteDirectory(string folder, string fileName)
        {
            testing.DeleteDirectory(folder, fileName);
            return Ok();
        }
        [HttpPost("write-to-directory")]
        public IActionResult WriteDirectory(IFormFile request, string folder)
        {
            testing.WriteDirectory(request, folder);
            return Ok();
        }
    }
}
