
using SQLite;

namespace ProductosMVVMQ12025.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Codigo { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public int Cantidad { get; set; }

        [NotNull]
        public double Precio { get; set; }
    }
}
