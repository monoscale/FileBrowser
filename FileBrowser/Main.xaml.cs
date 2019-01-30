using System.Windows;
using FileBrowser.Controls;
using FileBrowser.Model.DAL;
using FileBrowser.Model.Repositories;


namespace FileBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ICategoryRepository repository;


        public MainWindow() {
            InitializeComponent();
            repository = new CategoryRepository(new FileBrowserContext());


        }


        private void MenuButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            FileBrowserTreeView.PopulateTreeView();
        }
    }
}
