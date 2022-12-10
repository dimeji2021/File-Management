namespace FileManagementSystemService.IService
{
    public interface IFolderService
    {
        string CreatFolder(string name, string path);
        string DeleteFolder(string FolderPath);
        IEnumerable<string> GetFolder(string? path);
        string RenameFolder(string folderPath, string folder, string newFolder);
    }
}