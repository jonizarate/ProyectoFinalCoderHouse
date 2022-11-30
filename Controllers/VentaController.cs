using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/v2/[controller]")]
    public class VentaController : Controller
    {
        private VentaRepositories repoUsing = new VentaRepositories();
        [HttpGet]

        public IActionResult get()
        {
            try
            {

                List<Venta> listamostrar = repoUsing.ListaDeVentasCompletadas();
                return Ok(listamostrar);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
