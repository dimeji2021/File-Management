using ServiceStack.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemDomain.Dto_s
{
    public class RenameFolderDto
    {
        public string FolderPath { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;
        public string NewFolder { get; set; } = string.Empty;
    }
    public class RenameFolderDtoValidator : AbstractValidator<RenameFolderDto>
    {
        public RenameFolderDtoValidator()
        {
            RuleFor(x => x.FolderPath).NotEmpty().NotNull().WithMessage("Path name cannot be empty");
            RuleFor(x => x.FolderName).NotEmpty().NotNull().WithMessage("Folder name cannot be empty");
            RuleFor(x => x.NewFolder).NotEmpty().NotNull().WithMessage("New folder name cannot be empty");
        }
    }
}
