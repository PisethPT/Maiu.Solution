namespace EcommerceApp.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMyMzIyZTMwMmUzMFQzbzgyTlpiMGZDOTB6ZkxKdXZnTVdxVWt0Q0dRVWlXV0FqZUhGa2o4QzQ9");
            MainPage = new AppShell();
        }
    }
}
