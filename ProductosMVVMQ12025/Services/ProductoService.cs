
using ProductosMVVMQ12025.Models;
using SQLite;

namespace ProductosMVVMQ12025.Services
{
    public class ProductoService
    {
        private readonly SQLiteConnection _connection;

        public ProductoService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Producto>();
        }

        public List<Producto> GetAll(string Filtro = "")
        {
            // Validate if parameter is null or empty
            if (string.IsNullOrEmpty(Filtro))
            {
                return _connection.Table<Producto>().ToList();
            }

            return _connection.Table<Producto>()
                .Where(producto => producto.Codigo.ToLower().Contains(Filtro.ToLower()) || producto.Nombre.ToLower().Contains(Filtro.ToLower()))
                .ToList();            
        }

        public int Insert(Producto Producto)
        {
            return _connection.Insert(Producto);
        }

        public int Update(Producto Producto)
        {
            return _connection.Update(Producto);
        }

        public int Delete(Producto Producto)
        {
            return _connection.Delete(Producto);
        }
    }
}
