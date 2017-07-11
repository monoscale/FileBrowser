using MusicFiles.Forms;
using MusicFiles.Models;
using MusicFiles.Models.Repositories;
using MusicFiles.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace MusicFiles
{
    /// <summary>
    /// The main form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Private instance of a DirectoryRepository
        /// </summary>
        private DirectoryRepository directoryRepository;
        /// <summary>
        /// Private instance of a ExtensionRepository
        /// </summary>
        private ExtensionRepository extensionRepository;


        private ICollection<MusicDirectory> musicDirectories; // In-memory representation of all the directories

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        /* EVENTS RELATED TO THE WHOLE FORM*/
        #region MAINFORM EVENTS
        /// <summary>
        ///  Occurs when MainForm has loaded. Loads the settings and generates the treeview
        /// </summary>
        /// <param name="sender">MainForm</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Settings
            Text = Settings.Default.Title;
            if (!IsOnScreen(this))
            {
                Location = Settings.Default.WindowLocation;
            }

            Size = Settings.Default.WindowSize;
            Location = Settings.Default.WindowLocation;

            TreeViewDirectories.ForeColor = Settings.Default.ColorForeTreeView;
            TreeViewDirectories.BackColor = Settings.Default.ColorBackTreeView;
            PanelMenu.ForeColor = Settings.Default.ColorForeMenu;
            PanelMenu.BackColor = Settings.Default.ColorBackMenu;

            // Settings.Default.PropertyChanged += Settings_PropertyChanged;

            // TreeView
            directoryRepository = new DirectoryRepository();
            musicDirectories = directoryRepository.GetDirectories();
            extensionRepository = new ExtensionRepository();

            GenerateTree(musicDirectories);

        }

        /// <summary>
        /// Live color changing | NOT WORKING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName.StartsWith("Color"))
            {
                IList<string> settings = Enum.GetValues(typeof(ApplicationSetting)).Cast<ApplicationSetting>().Select(setting => setting.ToString()).ToList();
                Color color = (Color)Settings.Default.PropertyValues[e.PropertyName].PropertyValue;

                switch ((ApplicationSetting)Enum.Parse(typeof(ApplicationSetting), e.PropertyName, false))
                {
                    case ApplicationSetting.ColorBackMenu:
                        PanelMenu.BackColor = color;
                        break;
                    case ApplicationSetting.ColorBackTreeView:
                        TreeViewDirectories.BackColor = Settings.Default.ColorBackTreeView;
                        break;
                    case ApplicationSetting.ColorForeMenu:
                        PanelMenu.ForeColor = Settings.Default.ColorForeMenu;
                        break;
                    case ApplicationSetting.ColorForeTreeView:
                        TreeViewDirectories.BackColor = Settings.Default.ColorForeTreeView;
                        break;
                }
            }
        }

        /// <summary>
        /// Occurs when closing MainForm. Saves the location and size settings
        /// </summary>
        /// <param name="sender">MainForm</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.WindowLocation = Location;

            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = Size;
            }
            else
            {
                Settings.Default.WindowSize = RestoreBounds.Size;
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Sometimes the form can appear out of the screen (for example you disconnected your second monitor), thus being unable to bring the form back on your main screen.
        /// This method determines if the form is on any active monitor.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);
            foreach (Screen screen in screens)
            {

                if (screen.WorkingArea.Contains(formRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        /* EVENTS RELATED THE THE MENU */
        #region MENU EVENTS

        /// <summary>
        /// Refresh the treeview
        /// </summary>
        /// <param name="sender">MenuButton</param>
        /// <param name="e">EventArgs</param>

        private void MenuButtonRefresh_Click(object sender, EventArgs e)
        {
            GenerateTree(directoryRepository.GetDirectories());
        }


        /// <summary>
        /// Open the settings view
        /// </summary>
        /// <param name="sender">MenuButton</param>
        /// <param name="e">EventArgs</param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm()
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X + 40, Location.Y + 40) // A small offset so the new forms isn't perfectly over the old form
            };
            settingsForm.Show();

        }

        /// <summary>
        /// Opens the help view
        /// </summary>
        /// <param name="sender">MenuButton</param>
        /// <param name="e">EventArgs</param>
        private void MenuButtonGuide_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm()
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Location.X + 40, Location.Y + 40)
            };
            helpForm.Show();
        }
        #endregion

        /* EVENTS RELATED TO THE TREEVIEW */
        #region TREE
        /// <summary>
        /// Generates the treeview for the directories and files
        /// </summary>
        /// <param name="directories">A collection of the directories</param>
        /// <param name="isSearching">Indicates wether or not the directories should be expanded</param>
        private void GenerateTree(ICollection<MusicDirectory> directories, bool expand = false)
        {
            TreeViewDirectories.Nodes.Clear(); // Clear the view
            int index = 0;

            if (directories.Count == 0)
            {
                TreeNode notificationNode = new TreeNode
                {
                    Text = "You have not selected any directory yet. Go to the options menu.",
                    ForeColor = Color.OrangeRed
                };
                TreeViewDirectories.Nodes.Add(notificationNode);
                return;
            }

            foreach (MusicDirectory directory in directories)
            {
                try
                {
                    ICollection<FileInfo> files = directory.GetFiles(extensionRepository.GetExtensions());

                    TreeNode dirNode = new TreeNode()
                    {
                        Text = directory.Path,
                        Tag = NODE_STAT.DIRECTORY


                    };

                    TreeViewDirectories.Nodes.Add(dirNode);

                    foreach (FileInfo file in files)
                    {
                        TreeNode fileNode = new TreeNode()
                        {
                            Text = file.Name,
                            ToolTipText = file.FullName,
                            Tag = NODE_STAT.FILE
                        };

                        TreeViewDirectories.Nodes[index].Nodes.Add(fileNode);
                    }

                    if (dirNode.Nodes.Count == 0)
                    {
                        dirNode.Nodes.Add(new TreeNode
                        {
                            Text = "No matches found",
                            ForeColor = Color.Red
                        });
                    }

                    if (expand)
                    {
                        dirNode.Expand(); // Expands the directory
                        TreeViewDirectories.Nodes[0].EnsureVisible(); // make sure the top node is visible
                    }


                    index++;
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    TreeNode dirNode = new TreeNode()
                    {
                        Text = "(!) " + directory.Path,
                        ToolTipText = dnfe.Message
                    };
                    dirNode.ForeColor = Color.Red;
                    TreeViewDirectories.Nodes.Add(dirNode);
                }
            }
        }

        /// <summary>
        /// Occurs when there is doubleclicked inside the treeview. Opens a file if one was double clicked
        /// </summary>
        /// <param name="sender">TreeViewDirectories</param>
        /// <param name="e">TreeNodeMouseClickEventArgs</param>
        private void TreeViewDirectories_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    TreeNode selectedNode = e.Node;
                    if ((NODE_STAT)selectedNode.Tag == NODE_STAT.FILE)
                    {
                        ProcessStartInfo info = new ProcessStartInfo()
                        {
                            FileName = selectedNode.ToolTipText
                        };
                        Process.Start(info);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Occurs when right clicking inside the treeview. 
        /// Opens a menu where the user can select to open the folder if a folder was right clicked.
        /// If a file was right clicked, the user will get to choose wether or not to open the file location
        /// </summary>
        /// <param name="sender">TreeViewDirectories</param>
        /// <param name="e">TreeNodeMouseClickEventArgs</param>
        private void TreeViewDirectories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode selectedNode = e.Node;
                TreeView treeView = (TreeView)sender;
                treeView.SelectedNode = selectedNode; // A right click doesnt set the selected node, so we do it ourself

                ContextMenuStrip contextMenuNode = new ContextMenuStrip();
                ToolStripMenuItem OpenFolder = new ToolStripMenuItem();

                string path = ""; //predeclaration since the following if else statement fill this variable in a different way

                if ((NODE_STAT)selectedNode.Tag == NODE_STAT.FILE)
                {
                    path = selectedNode.ToolTipText;
                    path = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar;
                    OpenFolder.Text = "Open file location";

                }
                else if ((NODE_STAT)selectedNode.Tag == NODE_STAT.DIRECTORY)
                {
                    path = selectedNode.Text;
                    OpenFolder.Text = "Open folder";
                }
                OpenFolder.Click += (s, ea) => OpenFolder_Click(s, ea, path);

                contextMenuNode.Items.AddRange(new[] { OpenFolder });
                contextMenuNode.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Opens the windows file explorer for a given path
        /// </summary>
        /// <param name="sender">ToolStripMenuItem</param>
        /// <param name="e">EventArgs</param>
        /// <param name="path">The folder to open</param>
        private void OpenFolder_Click(object sender, EventArgs e, string path)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = path
            };
            Process.Start(info);
        }

        #endregion






        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            // We regenerate the full tree first, then delete what doesn't match. This causes a flicker since its deleting and rebuilding the tree
            GenerateTree(musicDirectories, true);
            string query = TextBoxSearch.Text.ToLower();
            // Start the deletion process
            List<TreeNode> nodesToDelete = new List<TreeNode>();
            // Iterate all the directories
            foreach (TreeNode directory in TreeViewDirectories.Nodes)
            {
                int nodeCount = directory.Nodes.Count;
                // Iterate all the files in this directory
                for (int i = 0; i < nodeCount; i++)
                {
                    TreeNode file = directory.Nodes[i]; // get current node
                    string fileName = file.Text.ToLower(); // text in lowercase
                    if (!(fileName.Contains(query))) // if not contains
                    {
                        nodesToDelete.Add(file); // mark node as deleted
                    }
                }
            }
            nodesToDelete.ForEach(f => f.Remove()); // Delete the nodes

            foreach (TreeNode directory in TreeViewDirectories.Nodes)
            {
                if (directory.Nodes.Count == 0)
                {
                    directory.Nodes.Add(new TreeNode
                    {
                        Text = "No matches found",
                        ForeColor = Color.Red
                    });
                }
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string input = TextBoxSearch.Text;
            if(string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                GenerateTree(musicDirectories, true);
            } 
        }


        /*
        Work in progress

        private List<TreeNodeProperties> nodeProperties = new List<TreeNodeProperties>();

        /// <summary>
        /// Updates the treeview to only show what matches the input. Is not case sensitive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // We must use the "TreeNode.Remove()" method here since there is nothing else available.
            // We keep track of the deleted nodes and move them back in if the query is empty or it matches.
            string query = TextBoxSearch.Text.ToLower();


            // Lets see if there are any nodes that can be put back
            foreach(TreeNodeProperties properties in nodeProperties)
            {
                string fileName = properties.Name.ToLower();
                if (fileName.Contains(query))
                {
                    //put back in the list
                }
            }
            
            // Start the deletion process
            List<TreeNode> nodesToDelete = new List<TreeNode>();
            // Iterate all the directories
            foreach (TreeNode directory in TreeViewDirectories.Nodes)
            {
                int nodeCount = directory.Nodes.Count;
                // Iterate all the files in this directory
                for (int i = 0; i < nodeCount; i++)
                {
                    TreeNode file = directory.Nodes[i]; // get current node
                    string fileName = file.Text.ToLower(); // text in lowercase
                    if (!(fileName.Contains(query))) // if not contains
                    {
                        nodesToDelete.Add(file); // mark node as deleted
                        nodeProperties.Add(new TreeNodeProperties
                        {
                            Parent = directory.Text,
                            Name = file.Text,
                            FullName = file.Text,
                            Index = i
                        });
                    }
                }
            }
            nodesToDelete.ForEach(f => f.Remove()); // Delete the nodes
        }
        */
    }
}
