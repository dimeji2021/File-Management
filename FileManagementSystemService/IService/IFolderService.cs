using FileManagementSystemDomain.Dto_s;

namespace FileManagementSystemService.IService
{
    public interface IFolderService
    {
        string CreatFolder(CreateFolderDto model);
        string DeleteFolder(string FolderPath);
        IEnumerable<string> GetFolder(string? path);
        string RenameFolder(RenameFolderDto model);
        IEnumerable<string> GetAllFilesInAPath(string path);
    }
}