using Client.Views;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var productListView = new ProductListView();
            productListView.Show();
        }

        private void ManufacturersButton_Click(object sender, RoutedEventArgs e)
        {
            var manufacturerListView = new ManufacturerListView();
            manufacturerListView.Show();
        }
    }
}