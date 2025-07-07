using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShippingRatesDemos.Resources.Translates;
using ShippingRatesDemos.Services;
using Shippo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.ViewModels
{
    public partial class SetupPageViewModel : ObservableObject
    {
        // ────────────── Bindables ──────────────────────────────────────
        [ObservableProperty]
        string apiKey = string.Empty;
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        bool isValidKey;

        public SetupPageViewModel()
        {
        }

        // Cada vez que cambia ApiKey valida si no está vacía
        partial void OnApiKeyChanged(string value) =>
            IsValidKey = !string.IsNullOrWhiteSpace(value);

            // ────────────── Commands ───────────────────────────────────────
            [RelayCommand]
            private async Task SaveKeyAsync()
            {
                if (IsBusy) return;

                IsBusy = true;

                try
                {
                    var sdk = new ShippoSDK(apiKeyHeader: ApiKey,
                                            shippoApiVersion: "201802-08");

                    await KeyStore.SaveAsync(ApiKey);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        var window = Application.Current?.Windows.FirstOrDefault();
                        if (window is not null)
                            window.Page = new AppShell();
                    });
            }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert(
                        AppResources.AlertErrorTitle,
                        ex.Message,
                        AppResources.AlertOkBtn);
                }
                finally { IsBusy = false; }
            }

        [RelayCommand]
        private async Task GoToFaqAsync() =>
         await Shell.Current.GoToAsync("//CreateAddressPage");
    }
}
