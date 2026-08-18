using Invoice_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using Invoice_System.DTOs;
using Invoice_System.Model;

namespace Invoice_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Category = dto.Category,
                UnitPrice = dto.UnitPrice,
                Discount = dto.Discount,
                IsHazardous = dto.IsHazardous,
                IsFragile = dto.IsFragile,
                StockQuantity = dto.StockQuantity,
                IsDiscountEligible = dto.Discount > 0
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }

    }
}
