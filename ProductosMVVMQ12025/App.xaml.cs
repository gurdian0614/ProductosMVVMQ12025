using ProductosMVVMQ12025.Views;

namespace ProductosMVVMQ12025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
    }
}
