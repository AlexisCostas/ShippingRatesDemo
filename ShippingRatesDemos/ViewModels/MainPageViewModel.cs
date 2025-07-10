using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shippo;
using Shippo.Models.Components;
namespace ShippingRatesDemos.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private bool _isNavigatedTo;
        private bool _dataLoaded;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        bool _isRefreshing;

        [ObservableProperty]
        private string _today = DateTime.Now.ToString("dddd, MMM d");

        private readonly ShippoSDK sdk;

        [ObservableProperty]
        Address address;
        public MainPageViewModel()
        {
            IsBusy = true;
        }
        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task Refresh()
        {
            try
            {
                IsRefreshing = true;
                await LoadData();
            }
            catch (Exception e)
            {
                // Handle exceptions, log errors, etc.
                Console.WriteLine($"Error refreshing data: {e.Message}");
                await AppShell.DisplayToastAsync($"Error refreshing data: {e.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private void NavigatedTo() =>
            _isNavigatedTo = true;

        [RelayCommand]
        private void NavigatedFrom() =>
            _isNavigatedTo = false;

        [RelayCommand]
        private async Task Appearing()
        {
            if (!_dataLoaded)
            {
                _dataLoaded = true;
                await Refresh();
            }
            // This means we are being navigated to
            else if (!_isNavigatedTo)
            {
                await Refresh();
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async Task GoToCreateAddressAsync()
        => await Shell.Current.GoToAsync(nameof(CreateAddressPage));

        [RelayCommand]
        private async Task GoToQuoteRatesAsync()
            => await Shell.Current.GoToAsync(nameof(QuoteRatesPage));
    }
}