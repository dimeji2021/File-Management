using FileManagementSystemDomain;
using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Http;
using SautinSoft.Document;
using ServiceStack.Web;
using System.IO;
//using ServiceStack;

namespace FileManagementSystemService.Service
{
    public class FileService : IFileService
    {
        public async Task<string> CreateFilesInAAFolder(string FolderPath, IFormFile file)
        {
            if (Directory.Exists(FolderPath))
            {
                var filePath = Path.Combine(FolderPath, file.FileName);
                using (FileStream fs = File.Create(filePath))
                return file.Name;
            }
            else
            {
                return "file does not exist";
            }
        }
        public string DeleteFiles(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return "sucessfully deleted";
            }
            return "File does not exist";
        }
        public string UpdateFile(string filepath, IFormFile newfileName)
        {
            if (File.Exists(filepath))
            {
                File.Replace(filepath, newfileName.Name, "");
                return "successful";
            }
            return "Path not found";
        }
    }
}
