using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FileBrowser.Model {
    [Table("Categories")]
    public class Category {
        [Key]
        public string Name { get; set; }

        public ICollection<Folder> Folders { get; set; }
        public ICollection<FileExtension> Extensions { get; set; }

        public Category() {
            Folders = new List<Folder>();
            Extensions = new List<FileExtension>();
        }

        public Category(string name) : this(name, new List<Folder>(), new List<FileExtension>()) { }

        public Category(string name, ICollection<Folder> folders, ICollection<FileExtension> extensions) {
            Name = name;
            Folders = folders;
            Extensions = extensions;
        }
    }
}
