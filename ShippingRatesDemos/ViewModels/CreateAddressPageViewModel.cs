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
        private readonly List<AddressTemplate> templates = new();
        [ObservableProperty] 
        bool canAutofill;
        private const int MaxAddresses = 5;
        private const string UsedKey = "UsedTemplates";   // CSV of indices (0-4)
        private const string CountKey = "CreatedCount";    

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

            LoadTemplates();          // <- fill the pool
            CanAutofill = templates.Any();
        }

        private void LoadTemplates()
        {
            // Master pool
            var master = new[]
            {
                new AddressTemplate("John Doe",   "ACME Inc.",  "215 Clayton St.", "San Francisco", "CA", "94117"),
                new AddressTemplate("Jane Smith", "Globex LLC", "350 5th Ave",     "New York",      "NY", "10118"),
                new AddressTemplate("Bob Stone",  "Wayne Co.",  "1007 Mountain",   "Gotham",        "NJ", "07097"),
                new AddressTemplate("Alice Wu",   "Initech",    "1 Infinite Loop", "Cupertino",     "CA", "95014"),
                new AddressTemplate("Carlos Díaz","Umbrella",   "1600 Amphitheatre Pkwy", "Mountain View", "CA", "94043")
            };

            templates.Clear();

            // Retrieve indices already used (csv "1,3")
            var csv = Preferences.Get(UsedKey, string.Empty);
            var usedIdx = csv.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse).ToHashSet();

            for (int i = 0; i < master.Length; i++)
                if (!usedIdx.Contains(i))
                    templates.Add(master[i]);            // keep unused only

            CreatedCount = Preferences.Get(CountKey, 0);
            CanAutofill = templates.Any() && CreatedCount < MaxAddresses;
        }

        private int CreatedCount { get; set; }

        private void InitializeFields()
        {
            Name = Company = Street1 = City = State =
            Zip = Phone = Email = string.Empty;
            Country = "US";
        }
        [RelayCommand]
        private async Task CreateAsync()
        {
            if (IsBusy || CreatedCount >= MaxAddresses) return;
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

                if (LastTemplateIndex is int idx && idx < templates.Count)
                {
                    // map index to original master pool index
                    int masterIdx = GetMasterIndex(templates[idx]);
                    RemoveTemplateFromPreferences(masterIdx);
                    templates.RemoveAt(idx);
                    LastTemplateIndex = null;
                }

                // Guarda el id en Preferences para usarlo en RatesPage
                Preferences.Set("LastAddressId", created.ObjectId);
                CreatedCount++;
                Preferences.Set(CountKey, CreatedCount);
                CanAutofill = templates.Any() && CreatedCount < MaxAddresses;

                // Limpia el formulario
                ClearFields();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand(CanExecute = nameof(CanAutofill))]
        private void Autofill()
        {
            if (!templates.Any()) return;

            var idx = Random.Shared.Next(templates.Count);
            var t = templates[idx];

            Name = t.Name;
            Company = t.Company;
            Street1 = t.Street1;
            City = t.City;
            State = t.State;
            Zip = t.Zip;
            Country = "US";
            Phone = "+1 555 123 4567";
            Email = $"{t.Name.ToLower().Replace(" ", "")}@example.com";

            // Keep index in Tag to know which template was used
            LastTemplateIndex = idx;
        }
        private int? LastTemplateIndex;   // index inside templates list

        private void ClearFields()
        {
            Name = Company = Street1 = City = State =
            Zip = Phone = Email = string.Empty;
            Country = "US";
        }

        private record AddressTemplate(
                    string Name, string Company, string Street1,
                    string City, string State, string Zip);
        private static int GetMasterIndex(AddressTemplate t) =>
                t.Name switch
                {
                    "John Doe" => 0,
                    "Jane Smith" => 1,
                    "Bob Stone" => 2,
                    "Alice Wu" => 3,
                    "Carlos Diaz" => 4 
                };

        private void RemoveTemplateFromPreferences(int masterIdx)
        {
            var csv = Preferences.Get(UsedKey, string.Empty);
            var list = csv.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (!list.Contains(masterIdx.ToString()))
            {
                list.Add(masterIdx.ToString());
                Preferences.Set(UsedKey, string.Join(',', list));
            }
        }
    }
}
