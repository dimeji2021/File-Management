using ServiceStack.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemDomain.Dto_s
{
    public class CreateFolderDto
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
    public class CreateFolderDtoValidator : AbstractValidator<CreateFolderDto>
    {
        public CreateFolderDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("cannot be empty");
            RuleFor(x => x.Path).NotEmpty().NotNull().WithMessage("path cannot be empty");
        }
    }
}
