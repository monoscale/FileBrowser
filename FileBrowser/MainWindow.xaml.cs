using System.Windows;


namespace FileBrowser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();

        }


        private void MenuButtonRefresh_OnClick(object sender, RoutedEventArgs e) {
            FileBrowserTreeView.PopulateTreeView();
        }
    }
}
