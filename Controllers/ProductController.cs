using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IgloobalTestBackendCSharp.Data;
using IgloobalTestBackendCSharp.Models;

namespace IgloobalTestBackendCSharp.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(new
            {
                status = "success",
                data = products
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = "error", message = "Datos inválidos" });
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return StatusCode(201, new
            {
                status = "success",
                data = product
            });
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null)
            {
                return NotFound(new { status = "error", message = $"Producto con ID {id} no encontrado" });
            }

            _context.Products.Remove(existing);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = "success",
                data = new { message = "Producto eliminado con éxito" }
            });
        }
    }
}