using EcommerceApp.Client.ViewModels;

namespace EcommerceApp.Client.Views.Phone;

public partial class PhoneHomePage : ContentPage
{
	public PhoneHomePage(PhoneHomePageViewModel phoneHomePageViewModel)
	{
		InitializeComponent();
		BindingContext = phoneHomePageViewModel;
	}
}