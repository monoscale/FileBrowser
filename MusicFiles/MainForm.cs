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
            TreeViewDirectories.ForeColor = Settings.Default.ColorForeTreeView;
            TreeViewDirectories.BackColor = Settings.Default.ColorBackTreeView;
            PanelMenu.ForeColor = Settings.Default.ColorForeMenu;
            PanelMenu.BackColor = Settings.Default.ColorBackMenu;

            // Settings.Default.PropertyChanged += Settings_PropertyChanged;
     
            // TreeView
            directoryRepository = new DirectoryRepository();
            extensionRepository = new ExtensionRepository();
       
            GenerateTree(directoryRepository.GetDirectories());

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
        /// A strange bug that sometimes makes this form appear out of the screens, thus being unable to bring it back
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
            TreeViewDirectories.Nodes.Clear();
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
        private void GenerateTree(ICollection<MusicDirectory> directories)
        {
            int index = 0;

            if(directories.Count == 0)
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
                treeView.SelectedNode = selectedNode; // A right click doesnt set the selected node, dus we do it ourself

                ContextMenuStrip contextMenuNode = new ContextMenuStrip();
                ToolStripMenuItem OpenFolder = new ToolStripMenuItem();

                string path = "";

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

        /// <summary>
        /// Keeping track wether or not a node in the tree is a directory or a file
        /// </summary>
        private enum NODE_STAT
        {
            FILE,
            DIRECTORY
        }


        #endregion


    }
}
