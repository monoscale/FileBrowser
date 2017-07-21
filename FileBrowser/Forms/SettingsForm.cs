using FileBrowser.FormControls.MessageBoxes;
using FileBrowser.Models;
using FileBrowser.Models.Language;
using FileBrowser.Models.Themes;
using FileBrowser.Persistence.Repositories;
using FileBrowser.Properties;
using FileBrowser.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FileBrowser.Forms {
    /// <summary>
    /// This form handles the settings
    /// </summary>
    public partial class SettingsForm : Form, ILocalizable {



        private RepositoryController repositoryController;
        private DependencyController dependencyController;

        private ObservableCollection<Folder> directories;
        private ObservableCollection<string> extensions;


        /// <summary>
        /// Event in case the user changes language
        /// </summary>
        public event EventHandler<EventArgs> LanguageChanged;
        /// <summary>
        /// Event in case the user changes a color
        /// </summary>
        public event EventHandler<EventArgs> ColorChanged;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsForm( RepositoryController repositoryController, DependencyController dependencyController ) {
            InitializeComponent();
            this.repositoryController = repositoryController;
            this.dependencyController = dependencyController;
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
        protected override void OnLoad( EventArgs e ) {

            directories = new ObservableCollection<Folder>();
            extensions = new ObservableCollection<string>();
            Icon = Properties.Resources.Icon;
            foreach(Folder directory in repositoryController.FolderRepository.GetFolders()) {
                directories.Add(directory);
            }

            foreach(string extension in repositoryController.ExtensionRepository.GetExtensions()) {
                extensions.Add(extension);
            }

            directories.CollectionChanged += Directories_CollectionChanged;
            extensions.CollectionChanged += Extensions_CollectionChanged;

            UpdateDirectories();
            UpdateExtensions();
            UpdateSettings();
            UpdateText();
            base.OnLoad(e);
        }

        public void UpdateSettings() {
            try {
                CheckBoxExpand.Checked = Settings.Default.Expand;
                ComboBoxLanguage.Items.AddRange(dependencyController.LanguageManager.GetReadableLanguages().ToArray());
                string code = dependencyController.LanguageManager.GetPreferredLanguageCode();
                string language = dependencyController.LanguageManager.CodeToLanguage(code);
                ComboBoxLanguage.SelectedItem = language;
            } catch(ArgumentException) {
                ErrorMessageBox.Show(Resources.Strings.InvalidLangugeTitle, Resources.Strings.InvalidLanguageDescription);
            }

            ComboBoxColorTheme.Items.AddRange(Enum.GetNames(typeof(Theme)));
            ComboBoxColorTheme.SelectedItem = dependencyController.ThemeManager.GetTheme().ToString();
        }

        /// <summary>
        /// Updates the UI text according to the chosen language
        /// </summary>
        public void UpdateText() {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(dependencyController.LanguageManager.GetPreferredLanguageCode());
            TitleBuilder titleBuilder = new TitleBuilder();
            Text = titleBuilder.BuildSecondaryTitle(Resources.Strings.MenuSettings);
            GroupBoxDirectories.Text = Resources.Strings.Directories;
            GroupBoxExtensions.Text = Resources.Strings.Extensions;
            ButtonAddDirectory.Text = Resources.Strings.AddDirectory;
            ButtonAddExtension.Text = Resources.Strings.AddExtension;
            GroupBoxSettings.Text = Resources.Strings.MenuSettings;
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
        private void ButtonAddDirectory_Click( object sender, EventArgs e ) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK) {
                string path = folderBrowserDialog.SelectedPath;
                Folder newDirectory = new Folder(path);
                if(directories.Contains(newDirectory)) {
                    ErrorMessageBox.Show(Resources.Strings.DuplicateFolderTitle, Resources.Strings.DuplicateFolderDescription);
                } else {
                    repositoryController.FolderRepository.AddFolder(path);
                    directories.Add(new Folder(path));
                }

            }
        }

        /// <summary>
        /// When right clicking an item in the list of directories, open up a menu that allows for editing or deleting.
        /// </summary>
        /// <param name="sender">ListViewDirectories</param>
        /// <param name="e">MouseEventArgs</param>
        private void ListViewDirectories_MouseClick( object sender, MouseEventArgs e ) {
            ListView listView = (ListView)sender;
            if(listView.SelectedItems.Count > 0) {
                ListViewItem selectedListViewItem = listView.SelectedItems[0];
                string path = selectedListViewItem.Text;
                if(e.Button == MouseButtons.Right) {
                    ContextMenuBuilder builder = new ContextMenuBuilder();
                    builder.Add("Edit", ( s, ea ) => EditDirectory_Click(s, ea, path));
                    builder.Add("Delete", ( s, ea ) => DeleteDirectory_Click(s, ea, path));
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
        private void EditDirectory_Click( object s, EventArgs e, string oldPath ) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK) {

                string newPath = folderBrowserDialog.SelectedPath;
                Folder newDirectory = new Folder(newPath); // new instance for comparing
                if(directories.Contains(newDirectory)) {
                    ErrorMessageBox.Show(Resources.Strings.DuplicateFolderTitle, Resources.Strings.DuplicateFolderDescription);
                } else {
                    repositoryController.FolderRepository.EditFolder(oldPath, newPath);
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
        private void DeleteDirectory_Click( object sender, EventArgs e, string path ) {
            repositoryController.FolderRepository.RemoveFolder(path);
            directories.Remove(directories.First(d => d.Path == path));
        }

        /// <summary>
        /// Updates the directorylist
        /// </summary>
        private void UpdateDirectories() {
            ListViewDirectories.Clear();
            foreach(Folder directory in directories) {
                ListViewDirectories.Items.Add(new ListViewItem(directory.Path));
            }
        }

        /// <summary>
        /// Listener on the observablelist 'directories' and updates the list of directories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Directories_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
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
        private void ButtonAddExtension_Click( object sender, EventArgs e ) {
            ButtonAddExtension.Visible = false;
            PanelAddExtension.Visible = true;
            TextBoxExtensionInput.Focus();
        }

        /// <summary>
        /// The user pressed "Submit" when adding an extension
        /// </summary>
        /// <param name="sender">ButtonSubmit</param>
        /// <param name="e">EventArgs</param>
        private void ButtonSubmit_Click( object sender, EventArgs e ) {
            AddExtension(TextBoxExtensionInput.Text);
        }

        /// <summary>
        /// The user pressed "Enter" when adding an extension
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxExtensionInput_KeyDown( object sender, KeyEventArgs e ) {
            if(e.KeyCode == Keys.Enter) {
                AddExtension(TextBoxExtensionInput.Text);
                e.SuppressKeyPress = true;

            }
        }

        /// <summary>
        /// Cancels the add operation
        /// </summary>
        /// <param name="sender">Button Cancel</param>
        /// <param name="e">EventArgs</param>
        private void ButtonCancel_Click( object sender, EventArgs e ) {
            AddExtensionComplete();
        }

        /// <summary>
        /// Validates the inputted extension and adds to the database if valid
        /// </summary>
        /// <param name="extension">The extension to validate</param>
        private void AddExtension( string extension ) {
            if(string.IsNullOrWhiteSpace(extension)) {
                WarningMessageBox.Show(Resources.Strings.InvalidExtensionTitle, Resources.Strings.InvalidExtensionEmpty);
                return;
            }

            // Add a . if the user forgets it
            if(!extension.StartsWith(".")) {
                extension = "." + extension;
            }

            if(extensions.Contains(extension)) {
                ErrorMessageBox.Show(Resources.Strings.DuplicateExtensionTitle, Resources.Strings.DuplicateExtensionDescription);
            } else {

                repositoryController.ExtensionRepository.AddExtension(extension);
                extensions.Add(extension);
                AddExtensionComplete();
            }
        }

        /// <summary>
        /// Stops the add extension process and revert to the default settings view
        /// </summary>
        private void AddExtensionComplete() {
            PanelAddExtension.Visible = false;
            ButtonAddExtension.Visible = true;
            TextBoxExtensionInput.Text = string.Empty;
        }

        /// <summary>
        /// When right clicking an item in the list of extensions, open up a menu that allows for deleting.
        /// </summary>
        /// <param name="sender">ListViewExtensions</param>
        /// <param name="e">MouseEventArgs</param>
        private void ListViewExtensions_MouseClick( object sender, MouseEventArgs e ) {
            ListView listView = (ListView)sender;
            if(listView.SelectedItems.Count > 0) {
                ListViewItem selectedListViewItem = listView.SelectedItems[0];
                string extension = selectedListViewItem.Text;
                if(e.Button == MouseButtons.Right) {
                    ContextMenuStrip ContextMenuDirectories = new ContextMenuStrip();

                    ToolStripMenuItem DeleteExtension = new ToolStripMenuItem(Resources.Strings.Delete);
                    DeleteExtension.Click += ( s, ea ) => DeleteExtension_Click(s, ea, extension);

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
        private void DeleteExtension_Click( object sender, EventArgs e, string extension ) {
            repositoryController.ExtensionRepository.RemoveExtension(extension);
            extensions.Remove(extension);
        }

        /// <summary>
        /// Listener on the observablelist 'extensions' and updates the list of extensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Extensions_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e ) {
            UpdateExtensions();
        }


        /// <summary>
        /// Updates the extensionlist
        /// </summary>
        private void UpdateExtensions() {
            ListViewExtensions.Clear();
            foreach(string extension in extensions) {
                ListViewExtensions.Items.Add(new ListViewItem(extension));
            }
        }
        #endregion

       
        


        /*
         * SETTINGS
         */
        #region SETTINGS

        private void CheckBoxExpand_CheckedChanged( object sender, EventArgs e ) {
            Settings.Default.Expand = CheckBoxExpand.Checked;
        }

        private void ComboBoxLanguage_SelectedIndexChanged( object sender, EventArgs e ) {
            try {
                string selected = (string)ComboBoxLanguage.SelectedItem;

                string code = dependencyController.LanguageManager.LanguageToCode(selected);
                dependencyController.LanguageManager.SavePreferredLanguageCode(code);
                UpdateText();
                LanguageChanged(this, new EventArgs());
            } catch(ArgumentException) {
                ErrorMessageBox.Show(Resources.Strings.InvalidLangugeTitle, Resources.Strings.InvalidLanguageDescription);
            }

        }

        private void ComboBoxColorTheme_SelectedIndexChanged( object sender, EventArgs e ) {
            string selected = (string)ComboBoxColorTheme.SelectedItem;
            Theme theme;
            Enum.TryParse(selected, out theme);
            dependencyController.ThemeManager.SetTheme(theme);
            ColorChanged(this, new EventArgs());
        }
    }

    #endregion


}

