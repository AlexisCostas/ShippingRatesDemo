using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShippingRatesDemos.Services;
using Shippo.Models.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.ViewModels
{
    public partial class QuoteRatesPageViewModel : ObservableObject
    {
        private readonly IShippoService _shippo;
        [ObservableProperty] 
        ObservableCollection<AddressItem> addresses = [];
        [ObservableProperty] 
        AddressItem? selectedFrom;
        [ObservableProperty] 
        AddressItem? selectedTo;
        public QuoteRatesPageViewModel(IShippoService shippo)
            => _shippo = shippo;

        private const int MaxFetch = 20;

        [ObservableProperty] 
        bool isBusy;
        [ObservableProperty] 
        ObservableCollection<Rate> rates = [];
        public bool CanGetRates => SelectedFrom is not null && SelectedTo is not null;

        partial void OnSelectedFromChanged(AddressItem? _, AddressItem? __) =>
            OnPropertyChanged(nameof(CanGetRates));
        partial void OnSelectedToChanged(AddressItem? _, AddressItem? __) =>
            OnPropertyChanged(nameof(CanGetRates));

        private const string IdListKey = "CreatedAddressIds";   // CSV

        [RelayCommand]
        private async Task AppearingAsync()
        {
            if (Addresses.Any()) return;           

            try
            {
                IsBusy = true;
                var list = await _shippo.ListAddressesAsync(MaxFetch);

                Addresses = new ObservableCollection<AddressItem>(list.Results?.Select(a => new AddressItem(a)) ?? Enumerable.Empty<AddressItem>());
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
        [RelayCommand]
        private async Task GetRatesAsync()
        {
            if (!CanGetRates) return;

            IsBusy = true;
            try
            {
                var parcel = Parcels.CreateParcelCreateRequest(new ParcelCreateRequest
                {
                    Length = "5",
                    Width = "5",
                    Height = "5",
                    DistanceUnit = DistanceUnitEnum.In,
                    Weight = "2",
                    MassUnit = WeightUnitEnum.Lb
                });

                var shipment = await _shippo.CreateShipmentAsync(new ShipmentCreateRequest
                {
                    AddressFrom = AddressFrom.CreateStr(SelectedFrom!.Id),
                    AddressTo = AddressTo.CreateStr(SelectedTo!.Id),
                    Parcels = new() { parcel },
                    Async = false
                });

                Rates = new(shipment.Rates);
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
        [RelayCommand]
        private async Task SelectRateAsync(Rate rate)
        {
            //await Shell.Current.GoToAsync("//BuyLabelPage",
            //    new Dictionary<string, object?> { ["RateId"] = rate.ObjectId });
        }

        public record AddressItem(string Id, string Display)
        {
            public AddressItem(Address a)
                : this(a.ObjectId!, $"{a.Name} — {a.City}, {a.State}") { }
            public override string ToString() => Display;   
        }

        [RelayCommand]
        private async Task GoBackAsync() => await Shell.Current.GoToAsync("..");
    }
}
