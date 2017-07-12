using MusicFiles.Forms;
using MusicFiles.Models;
using MusicFiles.Models.Repositories;
using MusicFiles.Properties;
using MusicFiles.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MusicFiles
{
    /// <summary>
    /// The main form
    /// </summary>
    public partial class MainForm : Form
    {
        private DirectoryRepository directoryRepository;
        private ExtensionRepository extensionRepository;

        /// <summary>
        /// In-memory representation of all the directories
        /// </summary>
        private ICollection<MusicDirectory> musicDirectories;

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

            extensionRepository = new ExtensionRepository();
            directoryRepository = new DirectoryRepository();
            musicDirectories = directoryRepository.GetDirectories();

            UpdateSizeAndLocation();
            UpdateColor();
            UpdateText();
            GenerateTree(musicDirectories, Settings.Default.Expand);
        }

        /// <summary>
        /// Sets the saved size and location of the form
        /// </summary>
        private void UpdateSizeAndLocation()
        {
            if (!FormUtils.IsOnScreen(this))
            {
                Location = Settings.Default.WindowLocation;
            }
            Size = Settings.Default.WindowSize;
            Location = Settings.Default.WindowLocation;
        }

        /// <summary>
        /// Update the color scheme
        /// </summary>
        private void UpdateColor()
        {
            TreeViewDirectories.ForeColor = Settings.Default.ColorForeTreeView;
            TreeViewDirectories.BackColor = Settings.Default.ColorBackTreeView;
            PanelMenu.ForeColor = Settings.Default.ColorForeMenu;
            PanelMenu.BackColor = Settings.Default.ColorBackMenu;
        }

        /// <summary>
        /// Updates the UI text according to the chosen language
        /// </summary>
        private void UpdateText()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Text = Settings.Default.Title; // title
            MenuButtonGuide.Text = Resources.Strings.MenuHelp;
            MenuButtonRefresh.Text = Resources.Strings.MenuRefresh;
            MenuButtonSettings.Text = Resources.Strings.MenuSettings;
            LabelSearch.Text = Resources.Strings.Search;
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
            musicDirectories = directoryRepository.GetDirectories(); // Reload in-memory object
            GenerateTree(musicDirectories, Settings.Default.Expand);
        }


        /// <summary>
        /// Open the settings view
        /// </summary>
        /// <param name="sender">MenuButton</param>
        /// <param name="e">EventArgs</param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.LanguageChanged += SettingsForm_LanguageChanged;
            FormUtils.OpenForm(settingsForm, Location);
        }

        private void SettingsForm_LanguageChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        /// <summary>
        /// Opens the help view
        /// </summary>
        /// <param name="sender">MenuButton</param>
        /// <param name="e">EventArgs</param>
        private void MenuButtonGuide_Click(object sender, EventArgs e)
        {
            FormUtils.OpenForm(new HelpForm(), Location);

        }
        #endregion

        /* EVENTS RELATED TO THE TREEVIEW */
        #region TREE
        /// <summary>
        /// Generates the treeview for the directories and files
        /// </summary>
        /// <param name="directories">A collection of the directories</param>
        /// <param name="expand">Indicates wether or not the directories should be expanded; default value is false</param>
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
                        ProcessUtils.StartProcess(selectedNode.ToolTipText);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxUtils.ShowError("Unexpected error", ex.Message);
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

                ContextMenuBuilder builder = new ContextMenuBuilder();

                string path = string.Empty; // The path of the file
                string text = string.Empty; // The text to show in the contextmenu

                if ((NODE_STAT)selectedNode.Tag == NODE_STAT.FILE)
                {
                    path = selectedNode.ToolTipText;
                    path = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar;
                    text = "Open file location";
                }
                else if ((NODE_STAT)selectedNode.Tag == NODE_STAT.DIRECTORY)
                {
                    path = selectedNode.Text;
                    text = "Open folder";
                }

                builder.Add(text, (s, ea) => OpenFolder_Click(s, ea, path));
                builder.Show();

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
            ProcessUtils.StartProcess(path);
        }


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
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                GenerateTree(musicDirectories, true);
            }
        }

        #endregion




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
