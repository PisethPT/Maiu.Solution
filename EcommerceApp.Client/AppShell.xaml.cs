using EcommerceApp.Client.Views.Desktop;

namespace EcommerceApp.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
        }
    }
}
