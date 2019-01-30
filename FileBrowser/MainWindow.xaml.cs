using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using FileBrowser.Model;
using FileBrowser.Model.DAL;
using FileBrowser.Model.Repositories;


namespace FileBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();
            ICategoryRepository repository = new CategoryRepository(new FileBrowserContext());
            repository.Add(new Category("my name is not important"));
            repository.SaveChanges();
            IEnumerable<Category> categories = repository.FindAll();

            Debug.WriteLine(categories.Count());




        }


        private void MenuButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            FileBrowserTreeView.PopulateTreeView();
        }
    }
}
