using Microsoft.AspNetCore.Http;
using ServiceStack.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemService.Service
{
    public class Testing
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

        public void DeleteDirectory(string folder)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            var path = GetFilePath(baseDirectory, $"{folder}\\");
            foreach (string directory in Directory.EnumerateDirectories(path))
            {
                DeleteDirectory(directory);
            }
            foreach (string file in Directory.EnumerateFiles(path))
            {
                File.Delete(file);
            }
            Directory.Delete(path);
        }
        public IEnumerable<string> ReadDirectory(string folder)
        {
            IEnumerable<string> files;
            string baseDirectory = Directory.GetCurrentDirectory();
            var path = GetFilePath(baseDirectory, $"{folder}\\");
            foreach (var directory in Directory.EnumerateDirectories(path))
            {
                ReadDirectory(folder);
            }
            foreach (string file in Directory.EnumerateFiles(path))
            {
                files = Directory.EnumerateFiles(file);
                return files;
            }
            return Enumerable.Empty<string>();
        }
        public async Task WriteDirectory(IFormFile request, string folder)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            var path = GetFilePath(baseDirectory, folder);
            if (Directory.Exists(path))
            {
                var filePath = GetFilePath(baseDirectory, $"{folder}\\{request.FileName}");
                FileInfo fileInfo = new(filePath);
                using (FileStream stream = new(path, FileMode.CreateNew))
                {
                    await request.CopyToAsync(stream);
                };
                await WriteDirectory(request, folder);
            }
            return;
        }
        private static string GetFilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
        //public bool Delete(string folder)
        //{
        //    string baseDirectory = Directory.GetCurrentDirectory();
        //    var path = GetFilePath(baseDirectory, $"{folder}\\");
        //    if (Directory.Exists(path))
        //    {
        //        Directory.Delete(path, true);
        //    }
        //    else
        //    {
        //        var dir = Directory.GetDirectories(path);
        //        foreach (string d in dir)
        //        {
        //            if (d == folder)
        //            {
        //                Directory.Delete(path, true);
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //public IEnumerable<string> ReadDirectory(string folder)
        //{

        //    string baseDirectory = Directory.GetCurrentDirectory();
        //    var path = GetFilePath(baseDirectory, $"{folder}\\");
        //    return Directory.EnumerateFiles(path);
        //}
        //public async Task WriteDirectory(IFormFile request, string folder)
        //{
        //    string baseDirectory = Directory.GetCurrentDirectory();
        //    var path = GetFilePath(baseDirectory, $"{folder}\\{request.FileName}");
        //    FileInfo fileInfo = new(path);
        //    if (!fileInfo.Exists)
        //    {
        //        fileInfo.Directory.Create();
        //    }
        //    using (FileStream stream = new(path, FileMode.CreateNew))
        //    {
        //        await request.CopyToAsync(stream);
        //    }
        //}

    }
}
