using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FileBrowser.Controls {

    public class FileBrowserTreeView : TreeView {
  

        /// <summary>
        /// Generates the treeview for the directories and files.
        /// </summary>
        /// <param name="expand">Indicates wether or not the directories should be expanded; default value is false.</param>
        public void PopulateTreeView(bool expand = false) {
           // Items.Clear();
            ICollection<string> folders = new List<string> { "C:\\Users\\counterpoint\\Google Drive\\Albumman" };
            ICollection<string> fileExtensions = new List<string> { ".als", ".gpx" };

            foreach (string folder in folders) {
                TreeViewItem folderItem = new TreeViewItem {
                    Header = folder
                };
                folderItem.Items.Add(new TreeViewItem {Header = "test"});
                Items.Add(folderItem);
            }

            UpdateLayout();
            
        }
    }
}
