using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Input;
using EcommerceApp.Client.Models;
using EcommerceApp.Client.Services;
using MvvmHelpers;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace EcommerceApp.Client.ViewModels;
public partial class AddProductViewModel : BaseViewModel
{
    
    public ObservableRangeCollection<Category> Categories { get; set; } = new();
    [ObservableProperty]
    private Product addProduct;
    private readonly IProductService productService;

    [ObservableProperty]
    private ImageSource? imageSource;

    [ObservableProperty]
    private Category? selectedCategory;

    public AddProductViewModel(IProductService productService)
    {
        Title = "Add Product";
        AddProduct = new Product();
        this.productService = productService;
        LoadCategories();
    }

    private async void LoadCategories()
    {
        var categories = await productService.GetCategoriesAsync();
        if (categories is null) return;
        if(categories.Count > 0)
            Categories.Clear();
        Categories.AddRange(categories);
    }

    [RelayCommand]
    public async Task AddImage()
    {
        var image = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select Product Images",
            FileTypes = FilePickerFileType.Images,
        });
        if(image is null)
            return;

        string imageFormat = string.Empty;
        if (image.FileName.ToLower().Contains(".png"))
            imageFormat = "image/png";
        if (image.FileName.ToLower().Contains(".jpg"))
            imageFormat = "image/jpg";

        if (imageFormat is not null || string.IsNullOrEmpty(imageFormat) || string.IsNullOrWhiteSpace(imageFormat))
        {
            byte[] imageByte;
            var imageFile = Path.Combine(FileSystem.CacheDirectory, image.FileName);
            var stream = await image.OpenReadAsync();
            using (MemoryStream memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                imageByte = memory.ToArray();
            }
            var convertedImage = Convert.ToBase64String(imageByte);
            AddProduct.Image = convertedImage;
            var imgToPng = string.Format($"data:{imageFormat};base64,{convertedImage}");

            var ing = Convert.FromBase64String(convertedImage);
            MemoryStream memoryStream = new(ing);
            ImageSource = ImageSource.FromStream(()=> memoryStream);
        }
        else
            await Shell.Current.DisplayAlert("Invalid", "Image Can't Convert.", "OK");
    }

    [RelayCommand]
    public async Task SaveProduct()
    {
        if (AddProduct is null)
            return;
        if (SelectedCategory is null)
            return;
        AddProduct.CategoryId = SelectedCategory.Id;
        var response = await productService.AddProductAsync(AddProduct);
        await MakeToastAsync(response.Message);
        
    }

    private async Task MakeToastAsync(string message)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        ToastDuration duration = ToastDuration.Long;
        double fontSize = 18;

        var toast = Toast.Make(message, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }
}

