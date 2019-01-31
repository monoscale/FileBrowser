using System.Collections.Generic;

namespace FileBrowser.Model {
    public class FileBrowserTreeItem {

        public FileBrowserTreeItem() {
            Children = new List<FileBrowserTreeItem>();
        }

        public FileBrowserTreeItem(string name) {
            Name = name;
            Children = new List<FileBrowserTreeItem>();
        }

        public string Name { get; set; }
        public List<FileBrowserTreeItem> Children { get; set; }
    }
}
