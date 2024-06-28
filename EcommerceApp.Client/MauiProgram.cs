using EcommerceApp.Client.ViewModels;
using EcommerceApp.Client.Views.Desktop;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace EcommerceApp.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DesktopHomePageViewModel>();
            builder.Services.AddSingleton<DesktopHomePage>();
            builder.Services.AddSingleton<AddProductViewModel>();
            builder.Services.AddSingleton<AddProductPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
