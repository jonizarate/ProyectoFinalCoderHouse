using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UsuarioRepositories
    {
        private SqlConnection? conexion;
        private string stringDeConexion = "Server=sql.bsite.net\\MSSQL2016;Database=cratoxss12345_sistema_gestion;User Id=cratoxss12345_sistema_gestion;Password=Cratoxss4505422;";


        public UsuarioRepositories()
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

        public List<Usuario> listaDeUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            try
            {
                using (SqlCommand command = new SqlCommand("select * from usuario", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader lector = command.ExecuteReader())
                    {
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                Usuario Usuarios = new Usuario();
                                Usuarios.Id = long.Parse(lector["Id"].ToString());
                                Usuarios.Nombre = lector["Nombre"].ToString();
                                Usuarios.Apellido = lector["Apellido"].ToString();
                                Usuarios.NombreUsuario = lector["NombreUsuario"].ToString();
                                Usuarios.Contraseña = lector["Contraseña"].ToString();
                                Usuarios.Mail = lector["Mail"].ToString();
                                listaDeUsuarios.Add(Usuarios);
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
            return listaDeUsuarios;

        }
    }
}
