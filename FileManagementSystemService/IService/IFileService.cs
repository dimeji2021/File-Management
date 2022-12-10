﻿using Microsoft.AspNetCore.Http;

namespace FileManagementSystemService.IService
{
    public interface IFileService
    {
        Task<string> CreateFilesInAAFolder(string FolderPath, IFormFile file);
        string DeleteFiles(string filepath);
        string UpdateFile(string filepath, IFormFile newfileName);
    }
}