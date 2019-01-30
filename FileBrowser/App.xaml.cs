using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FileBrowser.Model.DAL;
using FileBrowser.Model.Repositories;

namespace FileBrowser {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private FileBrowserContext context;

        private void StartUp(object sender, StartupEventArgs e) {
            context = new FileBrowserContext();
            new MainWindow(new CategoryRepository(context)).Show();
        }
    }
}
