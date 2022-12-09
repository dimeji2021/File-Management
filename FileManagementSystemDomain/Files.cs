using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystemDomain
{
    public class Files
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public long FileSizeBytes { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsTextFile { get; set; }
        public string TextContents { get; set; }
    }
}
