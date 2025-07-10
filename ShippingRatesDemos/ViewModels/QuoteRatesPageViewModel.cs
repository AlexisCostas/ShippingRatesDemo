using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShippingRatesDemos.Services;
using Shippo;
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

        public QuoteRatesPageViewModel(IShippoService shippo)
            => _shippo = shippo;

        [ObservableProperty] 
        bool isBusy;
        [ObservableProperty] 
        ObservableCollection<Rate> rates = [];

        private const string IdListKey = "CreatedAddressIds";   // CSV

        [RelayCommand]
        private async Task AppearingAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                //var shipment = await _shippo.CreateShipmentAsync(new ShipmentCreateRequest
                //{
                //    //AddressFrom = AddressFrom.CreateStr(FromAddressId!),   //  ← string ID
                //    //AddressTo = AddressTo.CreateStr(ToAddressId!),     //  ← string ID
                //    Parcels = new()
                //    {
                //    //Parcels.CreateParcelCreateRequest(new ParcelCreateRequest
                //    //{
                //    //    Length = "5", Width = "5", Height = "5",
                //    //    DistanceUnit = DistanceUnitEnum.In,
                //    //    Weight = "2", MassUnit = WeightUnitEnum.Lb
                //    //})
                //    },
                //    Async = false
                //});

                //Rates = new ObservableCollection<Rate>(shipment.Rates);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        private async Task SelectRateAsync()
        {
            AddressPaginatedList page = await _shippo.ListAddressesAsync();

            Console.WriteLine("Metodo ejecutado pelotudo");
            //not implemented yet
        }
    }
}
