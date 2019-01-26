using FileBrowser.FormControls.MessageBoxes;
using FileBrowser.FormControls.TreeNodes;
using FileBrowser.Persistence.Repositories;
using FileBrowser.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FileBrowser.Domain;
using FileBrowser.Domain.Language;
using FileBrowser.Domain.Models;
using FileBrowser.Domain.Themes;

namespace FileBrowser.FormControls {


    /// <summary>
    /// Subclass of <see cref="TreeView"/> with additional features
    /// </summary>
    public partial class DirectoryTreeView : TreeView, ILocalizable, IThemeable {


        private RepositoryController repositoryController;
        private DependencyController dependencyController;

        public DirectoryTreeView(RepositoryController repositoryController, DependencyController dependencyController) {
            InitializeComponent();
            this.repositoryController = repositoryController;
            this.dependencyController = dependencyController;
            ShowNodeToolTips = true;
        }



        public void UpdateText() {
            foreach (TreeNode directory in Nodes) {
                foreach (TreeNode file in directory.Nodes) {
                    if (file is ILocalizable node) {
                        node.UpdateText();
                    }
                }
            }
        }


        public void UpdateTheme() {

            BackColor = dependencyController.ThemeManager.ColorTheme.BackGroundTree;
            ForeColor = dependencyController.ThemeManager.ColorTheme.ForeGroundTree;
            foreach (TreeNode directory in Nodes) {
                if (directory is IThemeable dir) {
                    dir.UpdateTheme();
                }
                foreach (TreeNode file in directory.Nodes) {
                    if (file is IThemeable fil) {
                        fil.UpdateTheme();
                    }
                }
            }
        }



        /// <summary>
        /// Generates the treeview for the directories and files
        /// </summary>
        /// <param name="expand">Indicates wether or not the directories should be expanded; default value is false</param>
        public void Generate(bool expand = false) {

            Nodes.Clear(); // Clear the view
            ICollection<Folder> directories = repositoryController.FolderRepository.GetFolders();
            if (directories.Count == 0) {
                Enabled = false;
                Nodes.Add(new NoDirectoriesTreeNode(dependencyController.ThemeManager));
                return;
            }

            ICollection<string> extensions = repositoryController.ExtensionRepository.GetExtensions();
            Enabled = true;

            int index = 0;
            foreach (Folder directory in directories) {
                try {
                    ICollection<FileInfo> files = directory.GetFiles(extensions);

                    TreeNode dirNode = new DirectoryTreeNode(directory.Path);
                    Nodes.Add(dirNode);

                    foreach (FileInfo file in files) {
                        Nodes[index].Nodes.Add(new FileTreeNode(file.Name, file.FullName));
                    }

                    if (dirNode.Nodes.Count == 0) {
                        dirNode.Nodes.Add(new NoMatchesTreeNode(dependencyController.ThemeManager));
                    }

                    if (expand) {
                        dirNode.Expand(); // Expands the directory
                    }
                    index++;
                }
                catch (DirectoryNotFoundException dnfe) {
                    Nodes.Add(new DirectoryNotFoundTreeNode(directory.Path, dnfe.Message, dependencyController.ThemeManager));
                }
            }
            Nodes[0].EnsureVisible(); // make sure the top node is visible
        }



        public void Search(string query, ICollection<string> filteredExtensions) {
            BeginUpdate();
            Generate(true);


            List<TreeNode> nodesToDelete = new List<TreeNode>();


            if (!(string.IsNullOrWhiteSpace(query))) { // NOT null or whitespace
                query = query.ToLower();
                nodesToDelete.AddRange(GetTreeNodesToDeleteBasedOnQuery(query));
            }

            if (filteredExtensions.Count > 0) {
                nodesToDelete.AddRange(GetTreeNodesToDeleteBasedOnExtensions(filteredExtensions));
            }

            nodesToDelete.ForEach(f => f.Remove()); // Delete the nodes

            foreach (TreeNode directory in Nodes) {
                if (directory.Nodes.Count == 0 && !(directory is DirectoryNotFoundTreeNode)) {
                    directory.Nodes.Add(new NoMatchesTreeNode(dependencyController.ThemeManager));
                }
            }
            EndUpdate();
        }

        private ICollection<TreeNode> GetTreeNodesToDeleteBasedOnQuery(string query) {
            List<TreeNode> nodesToDelete = new List<TreeNode>();
            // Iterate all the directories
            foreach (TreeNode directory in Nodes) {
                int nodeCount = directory.Nodes.Count;
                // Iterate all the files in this directory
                for (int i = 0; i < nodeCount; i++) {
                    TreeNode file = directory.Nodes[i]; // get current node
                    string fileName = file.Text.ToLower(); // text in lowercase
                    if (!(fileName.Contains(query))) // if not contains
                    {
                        nodesToDelete.Add(file); // mark node as deleted
                    }
                }
            }

            return nodesToDelete;
        }

        private ICollection<TreeNode> GetTreeNodesToDeleteBasedOnExtensions(ICollection<string> extensions) {
            List<TreeNode> nodesToDelete = new List<TreeNode>();
            foreach (TreeNode directory in Nodes) {
                foreach (TreeNode file in directory.Nodes) {
                    bool matches = false;
                    string filename = file.Text.ToLower();
                    foreach (string ext in extensions) {
                        if (filename.Contains(ext)) {
                            matches = true;
                        }
                    }

                    if (!matches) {
                        nodesToDelete.Add(file);
                    }
                }
            }

            return nodesToDelete;
        }


        /// <summary>
        /// Opens the file that was doubleclicked
        /// </summary>
        /// <param name="clickedNode">The TreeNode that was clicked</param>
        public void DoubleClicked(TreeNode clickedNode) {
            try {
                TreeNode selectedNode = clickedNode;
                if ((NODE_STAT)selectedNode.Tag == NODE_STAT.FILE) {
                    Process.Start(selectedNode.ToolTipText);
                }
            }
            catch (Exception ex) {

                ErrorMessageBox.Show("Unexpected error", ex.Message);
            }
        }

        /// <summary>
        /// Opens a menu where the user can select to open the folder if a folder was right clicked.
        /// If a file was right clicked, the user will get to choose wether or not to open the file location
        /// </summary>
        /// <param name="clickedNode">The TreeNode that was rightclicked</param>
        public void RightClicked(TreeNode clickedNode) {
            SelectedNode = clickedNode; // A right click doesnt set the selected node, so we do it ourself


            if ((NODE_STAT)clickedNode.Tag == NODE_STAT.INVALID) {
                // This happens in the case a directory is no longer available on the filesystem
                return;
            }

            ContextMenuBuilder builder = new ContextMenuBuilder();
            string path = string.Empty; // The path of the file
            string text = string.Empty; // The text to show in the contextmenu

            if ((NODE_STAT)clickedNode.Tag == NODE_STAT.FILE) {
                builder.Add("Open with another program", (s, ea) => ChangeRunningProgram(s, ea, clickedNode.ToolTipText));

                path = clickedNode.ToolTipText;
                path = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar;
                text = "Open file location";
            }
            else if ((NODE_STAT)clickedNode.Tag == NODE_STAT.DIRECTORY) {
                path = clickedNode.Text;
                text = "Open folder";
            }

            builder.Add(text, (s, ea) => OpenFolder(s, ea, path));

            builder.Show();
        }


        /// <summary>
        /// Opens the windows dialog for choosing another program to run a file with
        /// </summary>

        private void ChangeRunningProgram(object sender, EventArgs e, string path) {

            Process process = new Process();

            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = "rundll32.exe";
            process.StartInfo.Arguments = "shell32,OpenAs_RunDLL " + path;
            process.Start();
        }

        /// <summary>
        /// Opens the windows file explorer for a given path
        /// </summary>
        /// <param name="sender">ToolStripMenuItem</param>
        /// <param name="e">EventArgs</param>
        /// <param name="path">The folder to open</param>
        private void OpenFolder(object sender, EventArgs e, string path) {
            Process.Start(path);
        }

    }
}
