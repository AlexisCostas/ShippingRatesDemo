using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shippo;
using Shippo.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.ViewModels
{
    public partial class CreateAddressPageViewModel : ObservableObject
    {
        [ObservableProperty] 
        string name;
        [ObservableProperty] 
        string company;
        [ObservableProperty] 
        string street1;
        [ObservableProperty] 
        string city;
        [ObservableProperty] 
        string state;
        [ObservableProperty] 
        string zip;
        [ObservableProperty] 
        string country = "US";
        [ObservableProperty] 
        string phone;
        [ObservableProperty] 
        string email;
        [ObservableProperty] 
        bool isBusy;
        private readonly ShippoSDK sdk;


        public CreateAddressPageViewModel()
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
            InitializeFields();
        }

        private void InitializeFields()
        {
            Name = Company = Street1 = City = State =
            Zip = Phone = Email = string.Empty;
            Country = "US";
        }
        [RelayCommand]
        private async Task CreateAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                var req = new AddressCreateRequest
                {
                    Name = Name,
                    Company = Company,
                    Street1 = Street1,
                    City = City,
                    State = State,
                    Zip = Zip,
                    Country = Country,
                    Phone = Phone,
                    Email = Email
                };

                var created = await sdk.Addresses.CreateAsync(req);

                await Shell.Current.DisplayAlert("Success",
                    $"Address ID: {created.ObjectId}", "OK");

                // Guarda el id en Preferences para usarlo en RatesPage
                Preferences.Set("LastAddressId", created.ObjectId);

                // Limpia el formulario
                ClearFields();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private void Autofill()
        {
            // Ejemplo: dirección “faker”.
            Name = "John Doe";
            Company = "ACME Inc.";
            Street1 = "215 Clayton St.";
            City = "San Francisco";
            State = "CA";
            Zip = "94117";
            Country = "US";
            Phone = "+1 555 123 4567";
            Email = "john.doe@example.com";
        }

        private void ClearFields()
        {
            Name = Company = Street1 = City = State =
            Zip = Phone = Email = string.Empty;
            Country = "US";
        }
    }
}
