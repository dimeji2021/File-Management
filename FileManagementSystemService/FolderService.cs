using Microsoft.AspNetCore.Http;
using System;

namespace FileManagementSystemService
{
    public class FolderService
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
            catch (Exception ex)
            {
                throw ex;
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
                    Folds.Add((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host + i.Substring(startIndex));
                }
                if (file.Length == 0) return Enumerable.Empty<string>();
                return Folds;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteFolder")]
        public IActionResult DeleteFolder(string FolderName, string? FolderPath)
        {
            try
            {
                string siteHost = (HttpContext.Request.IsHttps ? "https" : "http") + "://" + HttpContext.Request.Host;
                if (FolderPath == null) FolderPath = "";
                if (FolderPath.Contains(siteHost))
                {
                    int startIndex = siteHost.Length;
                    string newPath = FolderPath.Substring(startIndex);
                    FolderPath = rootPath + '/' + newPath;
                    Directory.Delete(Path.Combine(FolderPath, FolderName), true);
                    return Ok(FolderName + " folder Successfully deleted.");
                }
                Directory.Delete(Path.Combine(rootPath, FolderPath, FolderName), true);
                return Ok(FolderName + " folder Successfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
