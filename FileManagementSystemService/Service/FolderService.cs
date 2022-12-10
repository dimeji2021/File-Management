using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Http;
using System;

namespace FileManagementSystemService.Service
{
    public class FolderService : IFolderService
    {
        public string CreatFolder(string name, string path)
        {
            if (path is null)
            {
                var createdFolder = Directory.CreateDirectory(Path.Combine(name));
            }
            var folder = Directory.CreateDirectory(Path.Combine(path, name));
            return folder.Name;

        }
        public IEnumerable<string> GetFolder(string path)
        {
            if (path is not null)
            {
                return Directory.GetDirectories( path);
            }
            else
            {

                return Enumerable.Empty<string>();
            }
        }
        public string DeleteFolder(string FolderPath)
        {
            Directory.Delete(FolderPath, true);
            return " folder Successfully deleted.";
        }
        public string RenameFolder(string folderPath, string folder,string newFolder)
        {
            Directory.Move(Path.Combine(folderPath, folder), Path.Combine(folderPath, newFolder));
            return "Successfully Renamed";
        }
    }
}
