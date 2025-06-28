using ShippingRatesDemos.ViewModels;

namespace ShippingRatesDemos.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}