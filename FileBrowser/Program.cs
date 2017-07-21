using FileBrowser.Models;
using FileBrowser.Models.Language;
using FileBrowser.Models.Themes;
using FileBrowser.Persistence.Repositories;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FileBrowser {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            RepositoryController repositoryController = new RepositoryController {
                FolderRepository = new FolderRepository(),
                ExtensionRepository = new ExtensionRepository()
            };

            DependencyController dependencyController = new DependencyController {
                LanguageManager = new LanguageManager(),
                ThemeManager = new ThemeManager()
            };


            MainForm mainForm = new MainForm(repositoryController, dependencyController);

            Application.Run(mainForm);
        }

    }
}
