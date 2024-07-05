using EcommerceApp.Client.Models;
using EcommerceApp.Client.Services;
using MvvmHelpers;

namespace EcommerceApp.Client.ViewModels
{
    public partial class PhoneHomePageViewModel : BaseViewModel
    {
        private readonly IProductService productService;

        public ObservableRangeCollection<Product> Products { get; set; } = new();
        public PhoneHomePageViewModel(IProductService productService)
        {
            this.productService = productService;
            Title = "Available Products";
            GetProductsAsync();
        }

        private async void GetProductsAsync()
        {
            try
            {
                var products = await productService.GetProductsAsync();
                
                if (products == null)
                    return;
                if (products.Count > 0)
                    Products.Clear();
                foreach (var product in products)
                {
                    //ImageSource source;

                    //if (product.Image != null)
                    //{
                    //    var image = Convert.FromBase64String(product.Image);
                    //    MemoryStream memory = new(image);
                    //    source = ImageSource.FromStream(() => memory);
                    //    product.Image = source.ToString() ?? "";
                    //}
                    Products.Add(product);
                }
            }catch (Exception ex)
            {
               await Shell.Current.DisplayAlert("Bad Request", $"{ ex.Message}", "Ok");
            }
        }
    }
}
