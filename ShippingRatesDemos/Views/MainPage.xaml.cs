using ShippingRatesDemos.PageModels;

namespace ShippingRatesDemos.Pages
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