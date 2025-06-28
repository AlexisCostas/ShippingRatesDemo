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
            string apiKeyHeader = Environment.GetEnvironmentVariable("SHIPPO_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKeyHeader))
            {
                //Display alert informing the user that the API key is not set as enviroment variable
            }
            else
            {
                sdk = new ShippoSDK(
                    apiKeyHeader: Environment.GetEnvironmentVariable("SHIPPO_API_KEY")!, // clave TEST
                    shippoApiVersion: "201802-08");
            }
        }
        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                Address address = await sdk.Addresses.CreateAsync(
                                new AddressCreateRequest()
                                {
                                    Name = "Shawn Ippotle",
                                    Company = "Shippo",
                                    Street1 = "215 Clayton St.",
                                    City = "San Francisco",
                                    State = "CA",
                                    Zip = "94117",
                                    Country = "US",
                                    Phone = "+1 555 341 9393",
                                    Email = "shippotle@shippo.com",
                                }
                                    );
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
        }

        [RelayCommand]
        private async Task GoToCreateAddressAsync()
        => await Shell.Current.GoToAsync("//CreateAddressPage");
    }
}