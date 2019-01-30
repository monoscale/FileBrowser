using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileBrowser.Constants;
using FileBrowser.Model;

namespace FileBrowser.Controls {
    /// <summary>
    /// Interaction logic for FileBrowserTreeViewControl.xaml
    /// </summary>
    public partial class FileBrowserTreeViewControl : UserControl {
        public FileBrowserTreeViewControl() {
            InitializeComponent();
        }

        /// <summary>
        /// Generates the treeview for the directories and files.
        /// </summary>
        /// <param name="category">The category which contains the neccesary folders and extensions</param>
        /// <param name="expand">Indicates wether or not the directories should be expanded; default value is true.</param>
        public void PopulateTreeView(Category category, bool expand = true) {
            FileBrowserTreeView.Items.Clear();
            ICollection<Folder> folders = category.Folders;
            ICollection<FileExtension> fileExtensions = category.Extensions;

            Debug.WriteLine(folders.Count);

            foreach (Folder folder in folders) {
                TreeViewItem folderItem = new TreeViewItem {
                    Header = folder.Path,
                    Foreground = new SolidColorBrush(ColorPalette.ForeGroundTree)
                };

                ICollection<FileInfo> files = folder.GetFiles(fileExtensions);

                foreach (FileInfo file in files) {
                    folderItem.Items.Add(new TreeViewItem {
                        Header = file.Name,
                        Foreground = new SolidColorBrush(ColorPalette.ForeGroundTree)
                    });
                }

                FileBrowserTreeView.Items.Add(folderItem);
                if (expand) {
                    folderItem.IsExpanded = true;
                }
            }
        }
    }
}
