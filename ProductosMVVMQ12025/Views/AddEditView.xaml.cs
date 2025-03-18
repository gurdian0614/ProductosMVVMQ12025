using ProductosMVVMQ12025.Models;
using ProductosMVVMQ12025.ViewModels;

namespace ProductosMVVMQ12025.Views;

public partial class AddEditView : ContentPage
{
	AddEditViewModel viewModel;
	public AddEditView()
	{
		InitializeComponent();
		viewModel = new AddEditViewModel();
		BindingContext = viewModel;
	}

    public AddEditView(Producto Producto)
    {
        InitializeComponent();
        viewModel = new AddEditViewModel(Producto);
        BindingContext = viewModel;
    }
}