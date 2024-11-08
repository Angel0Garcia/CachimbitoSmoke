using CachimbitoSmoke.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CachimbitoSmoke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly CachimbitoSmokeDbContext _context;
        public ProductosController(CachimbitoSmokeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListaProductos()
        {
            var products = await _context.Productos.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> VerProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);

        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto product)
        {
            var productoExistente = await _context.Productos.FindAsync(id);

            productoExistente.name = product.name;
            productoExistente.price = product.price;
            productoExistente.description = product.description;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoBorrar = await _context.Productos.FindAsync(id);

            _context.Productos.Remove(productoBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
