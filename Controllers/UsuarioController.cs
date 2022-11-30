using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/v2/[controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioRepositories UsersRepo = new UsuarioRepositories();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> listUsers = UsersRepo.listaDeUsuarios();
                return Ok(listUsers);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
