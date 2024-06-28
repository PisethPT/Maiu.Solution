using EcommerceApp.Client.ViewModels;

namespace EcommerceApp.Client.Views.Desktop;

public partial class DesktopHomePage : ContentPage
{
	public DesktopHomePage(DesktopHomePageViewModel desktopHomePageViewModel)
	{
		InitializeComponent();
		BindingContext = desktopHomePageViewModel;
	}
}