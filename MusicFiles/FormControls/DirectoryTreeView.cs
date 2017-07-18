using FileBrowser.FormControls.MessageBoxes;
using FileBrowser.FormControls.TreeNodes;
using FileBrowser.Models;
using FileBrowser.Models.Language;
using FileBrowser.Persistence.Repositories;
using FileBrowser.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FileBrowser.FormControls {


    /// <summary>
    /// Subclass of <see cref="TreeView"/> with additional features
    /// </summary>
    public partial class DirectoryTreeView : TreeView, Localizable {

        private IFolderRepository folderRepository;
        private IExtensionRepository extensionRepository;

        public DirectoryTreeView( IFolderRepository folderRepository, IExtensionRepository extensionRepository ) {
            InitializeComponent();
            this.folderRepository = folderRepository;
            this.extensionRepository = extensionRepository;
            ShowNodeToolTips = true;
        }


        public void UpdateText() {
            foreach(TreeNode directory in Nodes) {
                foreach(TreeNode file in directory.Nodes) {
                    if(file is Localizable node) {
                        node.UpdateText();
                    }
                }
            }
        }

        /// <summary>
        /// Generates the treeview for the directories and files
        /// </summary>
        /// <param name="expand">Indicates wether or not the directories should be expanded; default value is false</param>
        public void Generate( bool expand = false ) {

            Nodes.Clear(); // Clear the view
            int index = 0;

            ICollection<Folder> directories = folderRepository.GetFolders();
            ICollection<string> extensions = extensionRepository.GetExtensions();

            if(directories.Count == 0) {
                Enabled = false;
                Nodes.Add(new NoDirectoriesTreeNode());
                return;
            }

            Enabled = true;
            foreach(Folder directory in directories) {
                try {
                    ICollection<FileInfo> files = directory.GetFiles(extensions);

                    TreeNode dirNode = new DirectoryTreeNode(directory.Path);
                    Nodes.Add(dirNode);

                    foreach(FileInfo file in files) {
                        Nodes[index].Nodes.Add(new FileTreeNode(file.Name, file.FullName));
                    }

                    if(dirNode.Nodes.Count == 0) {

                        dirNode.Nodes.Add(new NoMatchesTreeNode());
                    }

                    if(expand) {
                        dirNode.Expand(); // Expands the directory
                    }
                    index++;
                } catch(DirectoryNotFoundException dnfe) {
                    Nodes.Add(new DirectoryNotFoundTreeNode(directory.Path, dnfe.Message));
                }
            }
            Nodes[0].EnsureVisible(); // make sure the top node is visible
        }

        /// <summary>
        /// Searches the TreeView for occurences of the query parameter
        /// </summary>
        /// <param name="text">The string to search for</param>
        public void Search( string query ) {
            BeginUpdate();
            query = query.ToLower();
            Generate(true);
            List<TreeNode> nodesToDelete = new List<TreeNode>();
            // Iterate all the directories
            foreach(TreeNode directory in Nodes) {
                int nodeCount = directory.Nodes.Count;
                // Iterate all the files in this directory
                for(int i = 0; i < nodeCount; i++) {
                    TreeNode file = directory.Nodes[i]; // get current node
                    string fileName = file.Text.ToLower(); // text in lowercase
                    if(!( fileName.Contains(query) )) // if not contains
                    {
                        nodesToDelete.Add(file); // mark node as deleted
                    }
                }
            }

            nodesToDelete.ForEach(f => f.Remove()); // Delete the nodes

            foreach(TreeNode directory in Nodes) {
                if(directory.Nodes.Count == 0 && !(directory is DirectoryNotFoundTreeNode)) {
                    directory.Nodes.Add(new NoMatchesTreeNode());
                }
            }
            EndUpdate();
        }

        /// <summary>
        /// Only shows the files that match any of the extensions given as the parameter
        /// </summary>
        /// <param name="extensions">The list of extensions</param>
        public void FilterExtensions( ICollection<string> extensions ) {
            BeginUpdate();
            Generate(true);

            if(extensions.Count == 0) {
                EndUpdate();
                return;
            }

            List<TreeNode> nodesToDelete = new List<TreeNode>();
            foreach(TreeNode directory in Nodes) {
                foreach(TreeNode file in directory.Nodes) {
                    bool matches = false;
                    string filename = file.Text.ToLower();
                    foreach(string ext in extensions) {
                        if(filename.Contains(ext)) {
                            matches = true;
                        }
                    }

                    if(!matches) {
                        nodesToDelete.Add(file);
                    }
                }
            }

            nodesToDelete.ForEach(f => f.Remove()); // Delete the nodes

            foreach(TreeNode directory in Nodes) {
                if(directory.Nodes.Count == 0) {
                    directory.Nodes.Add(new NoMatchesTreeNode());

                }
            }
            EndUpdate();
        }

        /// <summary>
        /// Opens the file that was doubleclicked
        /// </summary>
        /// <param name="clickedNode">The TreeNode that was clicked</param>
        public void DoubleClicked( TreeNode clickedNode ) {
            try {
                TreeNode selectedNode = clickedNode;
                if((NODE_STAT)selectedNode.Tag == NODE_STAT.FILE) {
                    Process.Start(selectedNode.ToolTipText);
                }

            } catch(Exception ex) {

                ErrorMessageBox.Show("Unexpected error", ex.Message);
            }
        }

        /// <summary>
        /// Opens a menu where the user can select to open the folder if a folder was right clicked.
        /// If a file was right clicked, the user will get to choose wether or not to open the file location
        /// </summary>
        /// <param name="clickedNode">The TreeNode that was rightclicked</param>
        public void RightClicked( TreeNode clickedNode ) {
            SelectedNode = clickedNode; // A right click doesnt set the selected node, so we do it ourself


            if((NODE_STAT)clickedNode.Tag == NODE_STAT.INVALID) {
                // This happens in the case a directory is no longer available on the filesystem
                return;
            }

            ContextMenuBuilder builder = new ContextMenuBuilder();
            string path = string.Empty; // The path of the file
            string text = string.Empty; // The text to show in the contextmenu

            if((NODE_STAT)clickedNode.Tag == NODE_STAT.FILE) {
                path = clickedNode.ToolTipText;
                path = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar;
                text = "Open file location";
            } else if((NODE_STAT)clickedNode.Tag == NODE_STAT.DIRECTORY) {
                path = clickedNode.Text;
                text = "Open folder";
            }

            builder.Add(text, ( s, ea ) => OpenFolder_Click(s, ea, path));
            builder.Show();
        }

        /// <summary>
        /// Opens the windows file explorer for a given path
        /// </summary>
        /// <param name="sender">ToolStripMenuItem</param>
        /// <param name="e">EventArgs</param>
        /// <param name="path">The folder to open</param>
        private void OpenFolder_Click( object sender, EventArgs e, string path ) {
            Process.Start(path);
        }

    }
}
