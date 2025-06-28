using ShippingRatesDemos.ViewModels;

namespace ShippingRatesDemos.Views;

public partial class CreateAddressPage : ContentPage
{
	public CreateAddressPage(CreateAddressPageViewModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}