namespace WebApplication1.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public float PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

        public Producto()
        {
            Id = 0;
            Descripcion = "";
            Precio = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
        public Producto(long id, string descripcion, float precio, float precioVenta, int stock, long idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
    }
}
