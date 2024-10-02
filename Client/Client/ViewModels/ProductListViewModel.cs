using Client.Command;
using Client.Model;
using Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService;
        private readonly ManufacturerService _manufacturerService;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Manufacturer> AvailableManufacturers { get; set; } = new ObservableCollection<Manufacturer>();

        private Product? _selectedProduct;
        private string? _errorMessage;

        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged();
                    UpdateCommands();
                }
            }
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public bool IsErrorVisible => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProductListViewModel(ProductService productService, ManufacturerService manufacturerService)
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
            CreateCommand = new RelayCommand(CreateProduct);
            UpdateCommand = new RelayCommand(UpdateProduct, () => SelectedProduct != null);
            DeleteCommand = new RelayCommand(DeleteProduct, () => SelectedProduct != null);
        }

        public async Task LoadProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }

                var manufacturers = await _manufacturerService.GetAllAsync();

                AvailableManufacturers.Clear();
                foreach (var manufacturer in manufacturers)
                {
                    AvailableManufacturers.Add(manufacturer);
                }

                UpdateCommands();
                ErrorMessage = null; // Сбрасываем сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при загрузке продуктов: {ex.Message}";
            }
        }

        private async void CreateProduct()
        {
            try
            {
                var newProduct = new ProductRequest { Name = "Новый продукт" };
                await _productService.CreateAsync(newProduct);
                await LoadProductsAsync();

                ErrorMessage = null; // Сбрасываем сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при создании продукта: {ex.Message}";
            }
        }

        private async void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                try
                {
                    await _productService.UpdateAsync(new ProductRequest
                    {
                        Id = SelectedProduct.Id,
                        Name = SelectedProduct.Name,
                        Shape = SelectedProduct.Shape,
                        Dosage = SelectedProduct.Dosage,
                        ReleaseDate = SelectedProduct.ReleaseDate,
                        ExpirationDate = SelectedProduct.ExpirationDate,
                        ManufacturerId = SelectedProduct.ManufacturerId,
                    });
                    await LoadProductsAsync();

                    ErrorMessage = null; // Сбрасываем сообщение об ошибке
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка при обновлении продукта: {ex.Message}";
                }
            }
        }

        private async void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                try
                {
                    await _productService.DeleteAsync(SelectedProduct.Id);
                    await LoadProductsAsync();

                    ErrorMessage = null; // Сбрасываем сообщение об ошибке
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка при удалении продукта: {ex.Message}";
                }
            }
        }

        private void UpdateCommands()
        {
            ((RelayCommand)UpdateCommand).RaiseCanExecuteChanged();
            ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
