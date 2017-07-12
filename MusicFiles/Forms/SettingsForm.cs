using MusicFiles.Models;
using MusicFiles.Models.Repositories;
using MusicFiles.Properties;
using MusicFiles.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MusicFiles.Forms
{
    /// <summary>
    /// This form handles the settings
    /// </summary>
    public partial class SettingsForm : Form
    {
        private DirectoryRepository directoryRepository;
        private ExtensionRepository extensionRepository;

        private ObservableCollection<MusicDirectory> directories;
        private ObservableCollection<string> extensions;


        /// <summary>
        /// Special event in case the user switches language
        /// </summary>
        public event EventHandler<EventArgs> LanguageChanged;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }


        /**
         * All the code related to creating the SettingsForm
         */
        #region SETTINGSFORM

        /// <summary>
        /// Occurs when SettingsForm has loaded. Loads the color settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Text = Settings.Default.Title + " - Settings";

            directoryRepository = new DirectoryRepository();
            extensionRepository = new ExtensionRepository();

            directories = new ObservableCollection<MusicDirectory>();
            extensions = new ObservableCollection<string>();

            foreach (MusicDirectory directory in directoryRepository.GetDirectories())
            {
                directories.Add(directory);
            }

            foreach (string extension in extensionRepository.GetExtensions())
            {
                extensions.Add(extension);
            }

            directories.CollectionChanged += Directories_CollectionChanged;
            extensions.CollectionChanged += Extensions_CollectionChanged;

            UpdateDirectories();
            UpdateExtensions();
            UpdateSettings();
            UpdateColor();
            UpdateText();
        }

        private void UpdateSettings()
        {
            CheckBoxExpand.Checked = Settings.Default.Expand;
            LanguageMapper languageMapper = new LanguageMapper();
            ComboBoxLanguage.Items.AddRange(languageMapper.GetReadableLanguages().ToArray());
            string code = Settings.Default.Language;
            string language = languageMapper.CodeToLanguage(code);
            ComboBoxLanguage.SelectedItem = language;


        }

        private void UpdateColor()
        {
            ButtonForeMenuColor.BackColor = Settings.Default.ColorForeMenu;
            ButtonBackMenuColor.BackColor = Settings.Default.ColorBackMenu;

            ButtonForeTreeViewColor.BackColor = Settings.Default.ColorForeTreeView;
            ButtonBackTreeViewColor.BackColor = Settings.Default.ColorBackTreeView;
        }
        /// <summary>
        /// Updates the UI text according to the chosen language
        /// </summary>
        private void UpdateText()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            Text = Settings.Default.Title + " - " + Resources.Strings.MenuSettings;
            GroupBoxDirectories.Text = Resources.Strings.Directories;
            GroupBoxExtensions.Text = Resources.Strings.Extensions;
            ButtonAddDirectory.Text = Resources.Strings.AddDirectory;
            ButtonAddExtension.Text = Resources.Strings.AddExtension;
            GroupBoxSettings.Text = Resources.Strings.MenuSettings;
            GroupBoxColors.Text = Resources.Strings.Colors;
            LabelBackMenuColor.Text = Resources.Strings.MenuBackground;
            LabelForeMenuColor.Text = Resources.Strings.MenuForeground;
            LabelBackTreeViewColor.Text = Resources.Strings.ListBackground;
            LabelForeTreeViewColor.Text = Resources.Strings.ListForeground;
            ButtonReset.Text = Resources.Strings.Reset;
            CheckBoxExpand.Text = Resources.Strings.ExpandInfo;
            LabelLanguage.Text = Resources.Strings.SelectLanguage;

        }
        #endregion

        /**
         *  All the code related to adding, editing and deleting directories 
         */
        #region DIRECTORIES
        /// <summary>
        /// Add a new directory
        /// </summary>
        /// <param name="sender">ButtonAddDirectory</param>
        /// <param name="e">EventArgs</param>
        private void ButtonAddDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                MusicDirectory newDirectory = new MusicDirectory(path);
                if (directories.Contains(newDirectory))
                {
                    MessageBoxUtils.ShowError("Duplicate folder", "This folder is already in the list.");
                }
                else
                {
                    directoryRepository.AddDirectory(path);
                    directories.Add(new MusicDirectory(path));
                }

            }
        }

        /// <summary>
        /// When right clicking an item in the list of directories, open up a menu that allows for editing or deleting.
        /// </summary>
        /// <param name="sender">ListViewDirectories</param>
        /// <param name="e">MouseEventArgs</param>
        private void ListViewDirectories_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedListViewItem = listView.SelectedItems[0];
                string path = selectedListViewItem.Text;
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuBuilder builder = new ContextMenuBuilder();
                    builder.Add("Edit", (s, ea) => EditDirectory_Click(s, ea, path));
                    builder.Add("Delete", (s, ea) => DeleteDirectory_Click(s, ea, path));
                    builder.Show();
                }
            }
        }

        /// <summary>
        /// Edits a directory by letting the user chose a new directory
        /// </summary>
        /// <param name="s">ToolStripMenuItemEditDirectory (Created programmatically in ListViewDirectories_MouseClick)</param>
        /// <param name="e">EventArgs</param>
        /// <param name="oldPath">The path of the folder that is getting edited</param>
        private void EditDirectory_Click(object s, EventArgs e, string oldPath)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                string newPath = folderBrowserDialog.SelectedPath;
                MusicDirectory newDirectory = new MusicDirectory(newPath); // new instance for comparing
                if (directories.Contains(newDirectory))
                {
                    MessageBoxUtils.ShowError("Duplicate folder", "This folder is already in the list.");
                }
                else
                {
                    directoryRepository.EditDirectory(oldPath, newPath);
                    directories.First(d => d.Path == oldPath).Path = newPath;
                    UpdateDirectories();
                }

            }
        }

        /// <summary>
        /// Deletes a directory
        /// </summary>
        /// <param name="sender">ToolStripMenuItemDeleteDirectory (Created programmatically in ListViewDirectories_MouseClick)</param>
        /// <param name="e">EventArgs</param>
        /// <param name="path">The path of the folder that will be removed </param>
        private void DeleteDirectory_Click(object sender, EventArgs e, string path)
        {
            directoryRepository.RemoveDirectory(path);
            directories.Remove(directories.First(d => d.Path == path));
        }

        /// <summary>
        /// Updates the directorylist
        /// </summary>
        private void UpdateDirectories()
        {
            ListViewDirectories.Clear();
            foreach (MusicDirectory directory in directories)
            {
                ListViewDirectories.Items.Add(new ListViewItem(directory.Path));
            }
        }

        /// <summary>
        /// Listener on the observablelist 'directories' and updates the list of directories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Directories_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateDirectories();
        }


        #endregion

        /**
         *  All the code related to adding, editing and deleting extensions
         */
        #region EXTENSIONS

        /// <summary>
        /// Starts the process of adding an extension. Makes the button invisible and makes the input form visible
        /// </summary>
        /// <param name="sender">ButtonAddExtension</param>
        /// <param name="e">EventArgs</param>
        private void ButtonAddExtension_Click(object sender, EventArgs e)
        {
            ButtonAddExtension.Visible = false;
            PanelAddExtension.Visible = true;
            TextBoxExtensionInput.Focus();
        }

        /// <summary>
        /// The user pressed "Submit" when adding an extension
        /// </summary>
        /// <param name="sender">ButtonSubmit</param>
        /// <param name="e">EventArgs</param>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            AddExtension(TextBoxExtensionInput.Text);
        }

        /// <summary>
        /// The user pressed "Enter" when adding an extension
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxExtensionInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AddExtension(TextBoxExtensionInput.Text);
            }
        }

        /// <summary>
        /// Cancels the add operation
        /// </summary>
        /// <param name="sender">Button Cancel</param>
        /// <param name="e">EventArgs</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            AddExtensionComplete();
        }

        /// <summary>
        /// Validates the inputted extension and adds to the database if valid
        /// </summary>
        /// <param name="extension">The extension to validate</param>
        private void AddExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                MessageBoxUtils.ShowExclamation("Invalid extension", "The extension cannot be empty");
                return;
            }

            if (extension.Any(c => char.IsDigit(c)))
            {
                MessageBoxUtils.ShowExclamation("Invalid extension", "The extension cannot contain a number");
                return;
            }

            // Add a . if the user forgets it
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            if (extensions.Contains(extension))
            {
                MessageBoxUtils.ShowError("Duplicate extension", "This extension is already in the list.");
            }
            else
            {

                extensionRepository.AddExtension(extension);
                extensions.Add(extension);
                AddExtensionComplete();
            }
        }

        /// <summary>
        /// Stops the add extension process and revert to the default settings view
        /// </summary>
        private void AddExtensionComplete()
        {
            PanelAddExtension.Visible = false;
            ButtonAddExtension.Visible = true;
            TextBoxExtensionInput.Text = string.Empty;
        }

        /// <summary>
        /// When right clicking an item in the list of extensions, open up a menu that allows for deleting.
        /// </summary>
        /// <param name="sender">ListViewExtensions</param>
        /// <param name="e">MouseEventArgs</param>
        private void ListViewExtensions_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedListViewItem = listView.SelectedItems[0];
                string extension = selectedListViewItem.Text;
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip ContextMenuDirectories = new ContextMenuStrip();

                    ToolStripMenuItem DeleteExtension = new ToolStripMenuItem("Delete");
                    DeleteExtension.Click += (s, ea) => DeleteExtension_Click(s, ea, extension);

                    ContextMenuDirectories.Items.AddRange(new[] { DeleteExtension });
                    ContextMenuDirectories.Show(Cursor.Position);
                }
            }
        }

        /// <summary>
        /// Deletes an extension
        /// </summary>
        /// <param name="sender">ToolStripMenuItemDeleteExtension (Created programmatically in ListViewExtensions_MouseClick)</param>
        /// <param name="e">EventArgs</param>
        /// <param name="extension">The name of the extension that needs to be removed</param>
        private void DeleteExtension_Click(object sender, EventArgs e, string extension)
        {
            extensionRepository.RemoveExtension(extension);
            extensions.Remove(extension);
        }

        /// <summary>
        /// Listener on the observablelist 'extensions' and updates the list of extensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Extensions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateExtensions();
        }


        /// <summary>
        /// Updates the extensionlist
        /// </summary>
        private void UpdateExtensions()
        {
            ListViewExtensions.Clear();
            foreach (string extension in extensions)
            {
                ListViewExtensions.Items.Add(new ListViewItem(extension));
            }
        }
        #endregion

        /**
         * COLORS
         */
        #region COLORS
        /// <summary>
        /// Change the background color of PanelMenu
        /// </summary>
        /// <param name="sender">ButtonBackMenuColor</param>
        /// <param name="e">EventArgs</param>
        private void ButtonBackMenuColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ApplicationSetting.ColorBackMenu, (Button)sender);
        }

        /// <summary>
        /// Change the background color of TreeViewDirectories
        /// </summary>
        /// <param name="sender">ButtonBackTreeViewColor</param>
        /// <param name="e">EventArgs</param>
        private void ButtonBackTreeViewColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ApplicationSetting.ColorBackTreeView, (Button)sender);
        }

        /// <summary>
        /// Change the foreground color of PanelMenu
        /// </summary>
        /// <param name="sender">ButtonForeMenuColor</param>
        /// <param name="e">EventArgs</param>
        private void ButtonForeMenuColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ApplicationSetting.ColorForeMenu, (Button)sender);
        }

        /// <summary>
        /// Change the foreground color of TreeViewDirectories
        /// </summary>
        /// <param name="sender">ButtonForeTreeView</param>
        /// <param name="e">EventArgs</param>
        private void ButtonForeTreeViewColor_Click(object sender, EventArgs e)
        {
            ChangeColor(ApplicationSetting.ColorForeTreeView, (Button)sender);
        }

        /// <summary>
        /// Change a color and also the button that called it
        /// </summary>
        /// <param name="setting">The value of the setting that must be changed</param>
        /// <param name="button">The button that called this function</param>
        private void ChangeColor(ApplicationSetting setting, Button button)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PropertyValues[setting.ToString()].PropertyValue = ColorDialog.Color;
                button.BackColor = ColorDialog.Color;


            }
        }

        /// <summary>
        /// Resets all the color values to their default ones
        /// </summary>
        /// <param name="sender">ButtonReset</param>
        /// <param name="e">EventArgs</param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            ButtonBackMenuColor.BackColor = Settings.Default.ColorBackMenu;
            ButtonBackTreeViewColor.BackColor = Settings.Default.ColorBackTreeView;

            ButtonForeMenuColor.BackColor = Settings.Default.ColorForeMenu;
            ButtonForeTreeViewColor.BackColor = Settings.Default.ColorForeTreeView;
        }
        #endregion


        /*
         * SETTINGS
         */
        #region SETTINGS

        private void CheckBoxExpand_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Expand = CheckBoxExpand.Checked;
        }

        #endregion

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)ComboBoxLanguage.SelectedItem;
            LanguageMapper languageMapper = new LanguageMapper();
            string code = languageMapper.LanguageToCode(selected);
            Settings.Default.Language = code;
            UpdateText();
            LanguageChangedArgs args = new LanguageChangedArgs();
            args.Language = selected;
            args.Code = code;
            LanguageChanged(this, args);
        }

        private class LanguageChangedArgs : EventArgs
        {
            public string Language { get; set; }
            public string Code { get; set; }
        }
    }
}
