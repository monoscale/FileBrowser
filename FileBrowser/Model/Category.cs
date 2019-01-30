using System.Collections.Generic;

namespace FileBrowser.Model {

    public class Category {

        public int CategoryId { get; set; }
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
