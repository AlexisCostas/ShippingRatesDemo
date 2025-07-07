namespace ShippingRatesDemos.Views;

public partial class SetupPage : ContentPage
{
	public SetupPage()
	{
		InitializeComponent();
	}
    private void SfSegmentedControl_SelectionChanged(object sender,
            Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
    {
        Application.Current.UserAppTheme = e.NewIndex == 0
            ? AppTheme.Light : AppTheme.Dark;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ThemeSegmentedControl.SelectedIndex =
            Application.Current.UserAppTheme == AppTheme.Light ? 0 : 1;
    }
}