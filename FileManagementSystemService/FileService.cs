using FileManagementSystemDomain;
using Microsoft.AspNetCore.Http;
using SautinSoft.Document;
//using ServiceStack;

namespace FileManagementSystemService
{
    public class FileService : IFileService
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        //public string UploadFile(IFormFile file, string? FolderPath)
        //{
        //    try
        //    {
        //        string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host);
        //        if (FolderPath == null)
        //        {
        //            file.CopyTo(new FileStream(rootPath, FileMode.Create, FileAccess.Write));
        //            return "File created at: " + Path.Combine(rootPath, file.Name);
        //        }
        //        file.CopyTo(new FileStream(Path.Combine(rootPath, FolderPath), FileMode.Create, FileAccess.Write));
        //        return "File created at: " + Path.Combine(rootPath, FolderPath, file.Name);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public string CreateFile(string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        using (FileStream fs = File.Create(path))
        //        {
        //            return fs.Name;
        //        }; 
        //    }
        //   return "File \"{0}\" already exists.";
        //}
        //public void DeleteFiles(string file)
        //{
        //    if (File.Exists(file))
        //    {

        //        try
        //        {
        //           File.Delete(file);
        //        }
        //        catch (IOException e)
        //        {
        //            throw e; 
        //        }
        //    }
        //}

        public string CreateFilesByFolderName(string FolderName, string FileName)
        {
            var filepath = Path.Combine(rootPath, FolderName, FileName);
            File.Create(filepath);
            return filepath;
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
        public string[] GetAllFilesByFolderName(string folderName)
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            return files;
        }
        public string[] GetAllFileContentByFilePath(string filepath)
        {
            if (Directory.Exists(filepath))
            {
                return Directory.GetFiles(filepath);
            }
            return new string[0];
        }
        public string UpdateFileContent(string filepath, string newContent)
        {
            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, newContent);
                return "Successful";
            }
            return "Update Unsuccessful";
        }
        public string ReadFileContent(string filepath, string newContent)
        {
            if (File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
            return "file does not exist";
        }
        public string RenameFile(string filepath, string newfileName)
        {
            var newFilePath = Path.Combine(Path.GetDirectoryName(filepath), newfileName + Path.GetExtension(filepath));
            File.Move(filepath, newFilePath);
            return "File rename successfully";
        }
    }
}
