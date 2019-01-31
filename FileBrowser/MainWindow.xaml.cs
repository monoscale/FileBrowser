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

        private CategoryViewModel categoryViewModel;
        private FileBrowserTreeViewModel fileBrowserTreeViewModel;

        public MainWindow(ICategoryRepository repository) {

            InitializeComponent();
            this.repository = repository;

            categoryViewModel = new CategoryViewModel(repository);
            fileBrowserTreeViewModel = new FileBrowserTreeViewModel();



            CategoryUserControl.DataContext = categoryViewModel;
            FileBrowserTree.DataContext = fileBrowserTreeViewModel;


            fileBrowserTreeViewModel.Populate(categoryViewModel.SelectedCategory);
        }


        private void MenuButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            fileBrowserTreeViewModel.Populate(categoryViewModel.SelectedCategory);
        }
    }
}
