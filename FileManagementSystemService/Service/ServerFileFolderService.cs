using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Http;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemService.Service
{
    public class ServerFileFolderService : IServerFileFolderService
    {

        public void Create(string parentFolder)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            var path = GetFilePath(baseDirectory, $"{parentFolder}\\");
            FileInfo fileInfo = new(path);
            if (!fileInfo.Exists)
            {
                fileInfo.Directory.Create();
            }
        }
        public void Create(string parentFolder, string childFolder)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            var path = GetFilePath(baseDirectory, $"{parentFolder}\\");
            FileInfo fileInfo = new(path);
            if (!Directory.Exists(path))
            {
                fileInfo.Directory.Create();
            }
            var dir = Directory.GetDirectories(path);
            bool exist = false;
            foreach (string d in dir)
            {
                if (d == childFolder)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                path = GetFilePath(baseDirectory, $"{parentFolder}\\{childFolder}\\");
                fileInfo = new(path);
                if (!Directory.Exists(path))
                {
                    fileInfo.Directory.Create();
                }
            }
            Create(parentFolder, childFolder);
        }
        public string WriteDirectory(IFormFile file, string folder)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            var FolderPath = GetFilePath(baseDirectory, $"{folder}\\");

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
        public string DeleteDirectory(string folder, string fileName)
        {
            string[] files = Directory.GetFiles($"{folder}/");
            foreach (string file in files)
            {
                if (file.EndsWith(fileName))
                {
                    File.Delete(file);
                    break;
                }
            }
            return "delete successful";
        }
        private static string GetFilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
