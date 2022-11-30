using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoRepositories repositorii = new ProductoVendidoRepositories();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProductoVendido> listado = repositorii.listaDeProductosVendidos();
                return Ok(listado);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
