using Client.Services;
using Client.ViewModels;
using System.Net.Http;
using System.Windows;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerListView.xaml
    /// </summary>
    public partial class ManufacturerListView : Window
    {
        private readonly ManufacturerListViewModel _viewModel;

        public ManufacturerListView()
        {
            InitializeComponent();
            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7218/") };
            var apiService = new ManufacturerService(httpClient);
            _viewModel = new ManufacturerListViewModel(apiService);
            DataContext = _viewModel;
            Loaded += async (s, e) => await _viewModel.LoadManufacturersAsync();
        }
    }
}
