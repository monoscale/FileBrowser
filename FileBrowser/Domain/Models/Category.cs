using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileBrowser.Domain.Models {
    [Table("Categories")]
    public sealed class Category {
        [Key]
        public string Name { get; set; }

        public ICollection<Folder> Folders { get; set; }
        public ICollection<FileExtension> Extensions { get; set; }

        public Category() {
            Folders = new List<Folder>();
            Extensions = new List<FileExtension>();
        }
    }
}
