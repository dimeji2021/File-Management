namespace FileManagementSystemService
{
    public interface IFolderService
    {
        string CreateSubFolders(string FolderName, string SubFolderName);
        string CreatFolder(string name, string? path);
        string DeleteFolder(string FolderName, string? FolderPath);
        IEnumerable<string> GetFolder(string? FolderName);
        string RenameFolder(string FolderName, string FolderPath, string NewFolderName);
    }
}