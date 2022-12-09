using Microsoft.AspNetCore.Http;
using System;

namespace FileManagementSystemService
{
    public class FolderService : IFolderService
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        private IHttpContextAccessor _httpContextAccessor;
        public FolderService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreatFolder(string name, string? path)
        {
            try
            {
                if (path == null)
                {
                    var createdFolder = Directory.CreateDirectory(Path.Combine(rootPath, name));
                    return (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + createdFolder.Name);
                }
                var folder = Directory.CreateDirectory(Path.Combine(rootPath, path, name));
                return folder.Name;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string CreateSubFolders(string FolderName, string SubFolderName)
        {
            try
            {
                var file = Directory.GetDirectories(rootPath, FolderName, SearchOption.AllDirectories).FirstOrDefault();
                if (FolderName == null)
                {
                    return "Folder name does not exist";
                }
                Directory.CreateDirectory(Path.Combine(rootPath, file, SubFolderName));
                return SubFolderName;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<string> GetFolder(string? FolderName)
        {
            try
            {
                if (FolderName == null) FolderName = "";
                var file = Directory.GetDirectories(rootPath, FolderName, SearchOption.AllDirectories);
                List<string> Folds = new();
                foreach (var i in file)
                {
                    int startIndex = rootPath.Length;
                    Folds.Add((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host + i.Substring(startIndex)));
                }
                if (file.Length == 0) return Enumerable.Empty<string>();
                return Folds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RenameFolder(string FolderName, string FolderPath, string NewFolderName)
        {
            try
            {
                string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host);
                if (FolderPath.Contains(siteHost))
                {
                    int startIndex = siteHost.Length;
                    string newPath = FolderPath.Substring(startIndex);
                    FolderPath = rootPath + '/' + newPath;
                }
                Directory.Move(Path.Combine(FolderPath, FolderName), Path.Combine(FolderPath, NewFolderName));
                return "Successfully Renamed";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteFolder(string FolderName, string? FolderPath)
        {
            try
            {
                string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host);
                if (FolderPath == null) FolderPath = "";
                if (FolderPath.Contains(siteHost))
                {
                    int startIndex = siteHost.Length;
                    string newPath = FolderPath.Substring(startIndex);
                    FolderPath = rootPath + '/' + newPath;
                    Directory.Delete(Path.Combine(FolderPath, FolderName), true);
                    return FolderName + " folder Successfully deleted.";
                }
                Directory.Delete(Path.Combine(rootPath, FolderPath, FolderName), true);
                return FolderName + " folder Successfully deleted.";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
//"C:\\Users\\hp\\Desktop\\interview questions and answers\\FileManagementSystem\\FileManagementSystem\\x\\testingtesting"
//    C: \Users\hp\Desktop\interview questions and answers
//    "C:\\Users\\hp\\Desktop\\interview questions and answers\\FileManagementSystem\\FileManagementSystem"