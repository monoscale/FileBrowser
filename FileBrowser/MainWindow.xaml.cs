using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using FileBrowser.Model;
using FileBrowser.Model.DAL;
using FileBrowser.Model.Repositories;
using FileBrowser.ViewModel;


namespace FileBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ICategoryRepository repository;

        public MainWindow(ICategoryRepository repository) {
            
            InitializeComponent();
            this.repository = repository;
            CategoryUserControl.DataContext = new CategoryViewModel(repository);
            FileBrowserTreeView.PopulateTreeView(((CategoryViewModel)CategoryUserControl.DataContext).SelectedCategory);
        }


        private void MenuButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            FileBrowserTreeView.PopulateTreeView(((CategoryViewModel)DataContext).SelectedCategory);
        }
    }
}
