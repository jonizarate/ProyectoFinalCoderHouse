using System.Numerics;

namespace WebApplication1.Models
{
    public class Venta
    {
        public long Id { get; set; }
        public string Comentario { get; set; }
        public long IdUsuario { get; set; }
        public Venta() 
        {
            Id = 0;
            Comentario = "";
            IdUsuario = 0;
        }
        public Venta(long id, string comentario, long idUsuario)
        {
            Id = id;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }
    }
}
