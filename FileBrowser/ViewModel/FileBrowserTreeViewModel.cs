using System.Collections.Generic;
using System.Collections.ObjectModel;
using FileBrowser.Model;

namespace FileBrowser.ViewModel {
    public class FileBrowserTreeViewModel : ViewModel {

        public ObservableCollection<FileBrowserTreeItem> TreeViewItems { get; set; }

        public FileBrowserTreeViewModel() {
            TreeViewItems = new ObservableCollection<FileBrowserTreeItem>();
        }

        public void Populate(Category category) {
            TreeViewItems.Clear();
            foreach (Folder folder in category.Folders) {
                TreeViewItems.Add(folder.GetFiles(category.Extensions));
            }
        }
    }
}
