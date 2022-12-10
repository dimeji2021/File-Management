using FileManagementSystemDomain.Dto_s;
using FileManagementSystemService.IService;
using Microsoft.AspNetCore.Http;
using System;

namespace FileManagementSystemService.Service
{
    public class FolderService : IFolderService
    {
        public string CreatFolder(CreateFolderDto model)
        {
            var folder = Directory.CreateDirectory(Path.Combine(model.Path,model.Name));
            return folder.Name;
        }
        public IEnumerable<string> GetFolder(string? path)
        {
            if (path is not null)
            {
                return Directory.GetDirectories(path);
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }
        public string DeleteFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                return " folder Successfully deleted.";
            }
            return "folderPath does not exist";
        }
        public string RenameFolder(RenameFolderDto model)
        {
            Directory.Move(Path.Combine(model.FolderPath,model.FolderName), Path.Combine(model.FolderPath, model.NewFolder));
            return "Successfully Renamed";
        }
    }
}
