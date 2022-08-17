namespace DeviceSpecificSample.Views.Mobile;

public partial class MobileStartPage : ContentPage, IStartPage
{
	public MobileStartPage()
	{
		InitializeComponent();

        this.BindingContext = new StartPageViewModel(this.Navigation);
    }
}
