using FileBrowser.Models.Language;
using FileBrowser.Models.Themes;
using FileBrowser.Persistence.Repositories;
using System;
using System.Windows.Forms;

namespace FileBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            mainForm.SetRepositories(new FolderRepository(), new ExtensionRepository());
            mainForm.SetDependencies(new LanguageManager(), new ThemeManager());


            Application.Run(mainForm);
        }
    }
}
