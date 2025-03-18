
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVMQ12025.Models;
using ProductosMVVMQ12025.Services;

namespace ProductosMVVMQ12025.ViewModels
{
    public partial class AddEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string codigo;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private int cantidad;

        [ObservableProperty]
        private double precio;

        private ProductoService _service;

        public AddEditViewModel() {
            _service = new ProductoService();
        }

        public AddEditViewModel(Producto Producto) {
            _service = new ProductoService();
            Id = Producto.Id;
            Codigo = Producto.Codigo;
            Nombre = Producto.Nombre;
            Cantidad = Producto.Cantidad;
            Precio = Producto.Precio;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        private bool Validar(Producto Producto) {
            if (Producto.Codigo is null || Producto.Codigo == "") {
                Alerta("ADVERTENCIA", "Ingrese el código del producto");
                return false;
            } else if (Producto.Nombre is null || Producto.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del producto");
                return false;
            }

            return true;
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Producto Producto = new Producto() {
                    Id = Id,
                    Codigo = Codigo,
                    Nombre = Nombre,
                    Cantidad = Cantidad,
                    Precio = Precio,
                };

                if (Validar(Producto)) 
                {
                    if (Id == 0)
                    {
                        _service.Insert(Producto);
                    } else
                    {
                        _service.Update(Producto);
                    }

                    // Regresamos a la pantalla principal
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
