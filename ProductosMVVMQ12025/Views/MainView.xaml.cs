using ProductosMVVMQ12025.ViewModels;

namespace ProductosMVVMQ12025.Views;

public partial class MainView : ContentPage
{
	private MainViewModel viewModel;
	public MainView()
	{
		InitializeComponent();
		viewModel = new MainViewModel();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}