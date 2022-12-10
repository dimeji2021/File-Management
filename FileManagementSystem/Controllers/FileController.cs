﻿using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [SwaggerOperation(Summary = "This allows you upload a file in a directory, when the path is supplied")]
        [HttpPost("create")]
        public IActionResult CreateFilesInAAFolder(string FolderPath, IFormFile file)
        {
            var response = _fileService.CreateFilesInAAFolder(FolderPath, file);
            return Ok(response);
        }
        [SwaggerOperation(Summary = "This allows you delete a file when the path is supplied")]
        [HttpDelete("delete-file")]
        public IActionResult DeleteFiles(string filepath)
        {
            var response = _fileService.DeleteFiles(filepath);
            return Ok(response);
        }
        [SwaggerOperation(Summary = "This allows you update the file content of a directory")]
        [HttpPut("update-file-content")]
        public IActionResult UpdateFileContent(string filepath, IFormFile newfileName)
        {
            var response = _fileService.UpdateFile(filepath, newfileName);
            return Ok(response);
        }
    }
}
