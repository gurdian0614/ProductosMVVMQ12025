
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

        public List<Producto> GetAll()
        {
            return _connection.Table<Producto>().ToList();
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
