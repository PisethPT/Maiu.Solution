using EcommerceApp.Client.ViewModels;

namespace EcommerceApp.Client.Views.Desktop;

public partial class AddProductPage : ContentPage
{
	public AddProductPage(AddProductViewModel addProductViewModel)
	{
		InitializeComponent();
		BindingContext = addProductViewModel;
	}
}