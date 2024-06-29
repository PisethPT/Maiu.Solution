using CommunityToolkit.Mvvm.ComponentModel;
using EcommerceApp.Client.Models;
using System.Collections.ObjectModel;

namespace EcommerceApp.Client.ViewModels;
public partial class AddProductViewModel : BaseViewModel
{
    public ObservableCollection<Category> Categories { get; set; } = new();
    [ObservableProperty]
    private Product addProduct;
    public AddProductViewModel()
    {
        Title = "Add Product";
        AddProduct = new Product();
        LoadCategories();
    }

    private void LoadCategories()
    {
        throw new NotImplementedException();
    }
}

