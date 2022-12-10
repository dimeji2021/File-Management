using Microsoft.AspNetCore.Http;

namespace FileManagementSystemService.IService
{
    public interface IServerFileFolderService
    {
        void Create(string parentFolder);
        void Create(string parentFolder, string childFolder);
        string DeleteDirectory(string folder, string fileName);
        string WriteDirectory(IFormFile file, string folder);
    }
}