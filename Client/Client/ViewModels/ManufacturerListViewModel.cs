using Client.Command;
using Client.Model;
using Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class ManufacturerListViewModel : INotifyPropertyChanged
    {
        private readonly ManufacturerService _manufacturerService;
        public ObservableCollection<Manufacturer> Manufacturers { get; set; } = new ObservableCollection<Manufacturer>();

        private Manufacturer? _selectedManufacturer;
        private string? _errorMessage;

        public Manufacturer? SelectedManufacturer
        {
            get => _selectedManufacturer;
            set
            {
                if (_selectedManufacturer != value)
                {
                    _selectedManufacturer = value;
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

        public ManufacturerListViewModel(ManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
            CreateCommand = new RelayCommand(CreateManufacturer);
            UpdateCommand = new RelayCommand(UpdateManufacturer, () => SelectedManufacturer != null);
            DeleteCommand = new RelayCommand(DeleteManufacturer, () => SelectedManufacturer != null);
        }

        public async Task LoadManufacturersAsync()
        {
            try
            {
                var manufList = await _manufacturerService.GetAllAsync();
                Manufacturers.Clear();
                foreach (var manuf in manufList)
                {
                    Manufacturers.Add(manuf);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при загрузке производителей: {ex.Message}";
            }
        }

        private async void CreateManufacturer()
        {
            try
            {
                var newManufacturer = new ManufacturerRequest { Name = "Новый производитель" };
                await _manufacturerService.CreateAsync(newManufacturer);
                await LoadManufacturersAsync();

                ErrorMessage = null; // Сбрасываем сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при создании производителя: {ex.Message}";
            }
        }

        private async void UpdateManufacturer()
        {
            if (SelectedManufacturer != null)
            {
                try
                {
                    await _manufacturerService.UpdateAsync(new ManufacturerRequest
                    {
                        Id = SelectedManufacturer.Id,
                        Name = SelectedManufacturer.Name,
                        Country = SelectedManufacturer.Country,
                        
                    });
                    await LoadManufacturersAsync();

                    ErrorMessage = null; // Сбрасываем сообщение об ошибке
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка при обновлении производителя: {ex.Message}";
                }
            }
        }

        private async void DeleteManufacturer()
        {
            if (SelectedManufacturer != null)
            {
                try
                {
                    await _manufacturerService.DeleteAsync(SelectedManufacturer.Id);
                    await LoadManufacturersAsync();

                    ErrorMessage = null; // Сбрасываем сообщение об ошибке
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка при удалении производителя: {ex.Message}";
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
