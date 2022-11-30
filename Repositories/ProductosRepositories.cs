using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductosRepositories
    {
        private SqlConnection? conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";
        public ProductosRepositories()
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public List<Producto> listaDeProductos()
        {

            List<Producto> listaDeProductos = new List<Producto>();
            if (conexion == null)
            {
                throw new Exception("conexion no establecida");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto Productos = new Producto();
                                Productos.Id =long.Parse( reader["Id"].ToString());
                                Productos.Descripcion = reader["Descripciones"].ToString();
                                Productos.Precio =float.Parse( reader["Costo"].ToString());
                                Productos.PrecioVenta = float.Parse( reader["PrecioVenta"].ToString());
                                Productos.Stock = int.Parse(reader["Stock"].ToString());
                                Productos.IdUsuario = long.Parse(reader["IdUsuario"].ToString());
                                listaDeProductos.Add(Productos);
                            }
                        }
                        conexion.Close();
                    }
                }
            }
            catch
            {
                throw;
            }
            return listaDeProductos;
        }
    }
}
