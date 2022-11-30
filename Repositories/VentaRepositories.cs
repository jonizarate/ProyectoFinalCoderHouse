using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class VentaRepositories
    {
        private SqlConnection? conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";

        public VentaRepositories()
        {
            try
            {
                conexion = new SqlConnection(stringDeConexion);
            }
            catch (Exception ex )
            {

                Console.WriteLine("no se encontro el servidor"); 
            }
        }

        public List<Venta> ListaDeVentasCompletadas()
        {
            List<Venta> listaCompleta = new List<Venta>();
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Venta", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta Sold = new Venta();

                                Sold.Id = long.Parse(reader["Id"].ToString());
                                Sold.Comentario = reader["Comentarios"].ToString();
                                Sold.IdUsuario = long.Parse(reader["IdUsuario"].ToString());
                                listaCompleta.Add(Sold);

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
            return listaCompleta;
        }
    }
}
