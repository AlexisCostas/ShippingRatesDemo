using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShippingRatesDemos.Services;
using ShippingRatesDemos.ViewModels;
using Shippo;
using Syncfusion.Maui.Toolkit.Hosting;

namespace ShippingRatesDemos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
#if IOS || MACCATALYST
    				handlers.AddHandler<Microsoft.Maui.Controls.CollectionView, Microsoft.Maui.Controls.Handlers.Items2.CollectionViewHandler2>();
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                });

#if DEBUG
    		builder.Logging.AddDebug();
    		builder.Services.AddLogging(configure => configure.AddDebug());
#endif
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<CreateAddressPageViewModel>();
            builder.Services.AddSingleton<SetupPageViewModel>();
            builder.Services.AddSingleton<QuoteRatesPageViewModel>();


            var apiKey = KeyStore.GetAsync().GetAwaiter().GetResult();

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                builder.Services.AddSingleton<IShippoService>(_ => new ShippoService(apiKey));
            }


            return builder.Build();
        }
    }
}
