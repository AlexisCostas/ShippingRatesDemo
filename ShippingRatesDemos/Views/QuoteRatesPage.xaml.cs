namespace ShippingRatesDemos.Views;

public partial class QuoteRatesPage : ContentPage
{
	public QuoteRatesPage(QuoteRatesPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}