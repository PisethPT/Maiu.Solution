using CommunityToolkit.Mvvm.ComponentModel;

namespace EcommerceApp.Client.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string title;
}

