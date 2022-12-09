using Microsoft.AspNetCore.Http;

namespace FileManagementSystemService.IService
{
    public interface IFileService
    {
        string CreateFilesByFolderName(string FolderName, string FileName);
        string DeleteFiles(string filepath);
        string[] GetAllFileContentByFilePath(string filepath);
        string[] GetAllFilesByFolderName(string folderName);
        string ReadFileContent(string filepath, string newContent);
        string RenameFile(string filepath, string newfileName);
        string UpdateFileContent(string filepath, string newContent);
        string UploadFile(IFormFile file, string? FolderPath);
    }
}