using Microsoft.AspNetCore.Http;

namespace FileManagementSystemService
{
    public interface IFileService
    {
        string UploadFile(IFormFile file, string? FolderPath);
    }
}