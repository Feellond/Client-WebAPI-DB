using Client.Services;
using Client.ViewModels;
using System.Net.Http;
using System.Windows;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductListView.xaml
    /// </summary>
    public partial class ProductListView : Window
    {
        private readonly ProductListViewModel _viewModel;

        public ProductListView()
        {
            InitializeComponent();
            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7218/") };
            var productService = new ProductService(httpClient);
            var manufService = new ManufacturerService(httpClient);

            _viewModel = new ProductListViewModel(productService, manufService);
            DataContext = _viewModel;
            Loaded += async (s, e) => await _viewModel.LoadProductsAsync();
        }
    }

    
}
