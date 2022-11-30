using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductoVendidoRepositories
    {
        private SqlConnection? conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";

        public ProductoVendidoRepositories()
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
        public List<ProductoVendido> listaDeProductosVendidos()
        {
            List<ProductoVendido > listProductoVendido = new List<ProductoVendido>();
            if (conexion == null)
            {
                throw new Exception("No se encontro servidor");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido prodVenta = new ProductoVendido();
                                prodVenta.Id = long.Parse(reader["Id"].ToString());
                                prodVenta.Stock = int.Parse(reader["Stock"].ToString());
                                prodVenta.IdProducto = long.Parse(reader["IdProducto"].ToString());
                                prodVenta.IdVenta = long.Parse(reader["IdVenta"].ToString());
                                listProductoVendido.Add(prodVenta);
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

            return listProductoVendido;
        }
    }
}
