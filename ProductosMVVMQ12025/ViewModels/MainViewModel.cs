
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVMQ12025.Models;
using ProductosMVVMQ12025.Services;
using ProductosMVVMQ12025.Views;
using System.Collections.ObjectModel;

namespace ProductosMVVMQ12025.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Producto> productoCollection = new ObservableCollection<Producto>();

        [ObservableProperty]
        private string buscarProducto;

        private readonly ProductoService _service;

        public MainViewModel()
        {
            _service = new ProductoService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var list = _service.GetAll();

            if (list.Count > 0)
            {
                ProductoCollection.Clear();
                foreach (var producto in list)
                {
                    ProductoCollection.Add(producto);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }

        private async Task GoToEdit(Producto Producto)
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(Producto));
        }

        [RelayCommand]
        private async Task Select(Producto Producto)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await GoToEdit(Producto);
                }
                else if (res == ELIMINAR)
                {
                    await Eliminar(Producto);
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private async Task Eliminar(Producto Producto)
        {
            try
            {
                bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PRODUCTO", "¿Desea eliminar el producto?", "Si", "No");

                if (respuesta) { 
                    int del = _service.Delete(Producto);

                    if (del > 0) {
                        Alerta("ELIMINAR PRODUCTO", "Producto eliminado correctamente.");
                        ProductoCollection.Remove(Producto);
                    }
                }
            }
            catch (Exception ex) {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private void Buscar()
        {
            try
            {
                ProductoCollection.Clear();
                var resultado = _service.GetAll(BuscarProducto);

                foreach (var producto in resultado)
                {
                    ProductoCollection.Add(producto);
                }
            }
            catch (Exception ex) {
                 Alerta("ERROR", ex.Message);
            }
            
        }

        partial void OnBuscarProductoChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                GetAll();
            } else
            {
                Buscar();
            }
        }
    }
}
