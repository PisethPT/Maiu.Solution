using CommunityToolkit.Maui;
using EcommerceApp.Client.Services;
using EcommerceApp.Client.ViewModels;
using EcommerceApp.Client.Views.Desktop;
using EcommerceApp.Client.Views.Phone;
using Microsoft.Extensions.Logging;

namespace EcommerceApp.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DesktopHomePageViewModel>();
            builder.Services.AddSingleton<DesktopHomePage>();

            builder.Services.AddSingleton<AddProductViewModel>();
            builder.Services.AddSingleton<AddProductPage>();

            builder.Services.AddSingleton<PhoneHomePageViewModel>();
            builder.Services.AddSingleton<PhoneHomePage>();

            builder.Services.AddHttpClient<IProductService, ProductService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
