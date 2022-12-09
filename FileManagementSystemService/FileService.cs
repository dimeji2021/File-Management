using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemService
{
    public class FileService : IFileService
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        private IHttpContextAccessor _httpContextAccessor;
        public string UploadFile(IFormFile file, string? FolderPath)
        {
            try
            {
                string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http" + "://" + _httpContextAccessor.HttpContext.Request.Host);
                if (FolderPath == null)
                {
                    file.CopyTo(new FileStream(rootPath, FileMode.Create, FileAccess.Write));
                    return "File created at: " + Path.Combine(rootPath, file.Name);
                }
                file.CopyTo(new FileStream(Path.Combine(rootPath, FolderPath), FileMode.Create, FileAccess.Write));
                return "File created at: " + Path.Combine(rootPath, FolderPath, file.Name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
