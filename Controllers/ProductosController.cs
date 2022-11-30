using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductosController : Controller
    {
        private ProductosRepositories repository = new ProductosRepositories();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Producto> lista = repository.listaDeProductos();
                return Ok(lista);
            }
            catch (Exception ex )
            {

                return Problem(ex.Message);
            }
        }
    }
}
