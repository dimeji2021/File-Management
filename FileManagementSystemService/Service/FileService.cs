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
        public string CreateFilesInAAFolder(string FolderPath, IFormFile file)
        {
            if (Directory.Exists(FolderPath))
            {
                var filePath = Path.Combine(FolderPath, file.FileName);
                using (FileStream fs = File.Create(filePath))
                return file.Name;
            }
            else
            {
                return "folder does not exist";
            }
        }
        public string DeleteFiles(string filepath)
        {
            if (filepath is not null)
            {
                File.Delete(filepath);
                return "sucessfully deleted";
            }
            else
            {
                return "supply a correct file path to delete";
            }
            
        }
        public string UpdateFile(string filepath, IFormFile newfileName)
        {
            if (File.Exists(filepath))
            {
                var path = Path.GetFullPath(filepath);
                var newFilePath = Path.Combine(path, newfileName.FileName);
                File.Replace(filepath, newFilePath, path);
                return "update successful";
            }
            return "Path not found";
        }
        private static string GetFilePath(string filepath, string fileName)
        {
            return Path.Combine(filepath, fileName);
        }
    }
}
