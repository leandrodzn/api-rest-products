using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiNetV1.Context;
using RestApiNetV1.Models;
using RestApiNetV1.DTOs;

namespace RestApiNetV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly decimal IVAPercentage = 16;

        public ProductsController(AppDbContext context) {
            _context = context;
        }
        private async Task<bool> ProductExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(product => product.Id == id);
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();
            
            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product) {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product); // Add to location header new product route
        }

        // PUT: api/Products/5
        // IActionResult allow to return variety of responses types
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product) {
            if (id != product.Id) return BadRequest();
            
            _context.Entry(product).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!await ProductExistsAsync(id)) return NotFound();
                else throw;
            }

            // Find register
            var updatedProduct = await _context.Products.FindAsync(id);
            return Ok(updatedProduct);
        }

        // Operation to check total amount for a product and a quantity
        [HttpGet("{id}/amount/{quantity}")]
        public async Task<ActionResult<ProductAmountDTO>> GetProductAmount(int id, int quantity)
        {
            if (quantity < 1) return BadRequest();

            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            if (quantity > product.Amount) return BadRequest();

            // Operations
            var subtotal = product.Price * quantity;
            var IVA = subtotal * (IVAPercentage / 100);
            var total = subtotal + IVA;

            // Round to two decimals
            subtotal = Math.Round(subtotal, 2);
            IVA = Math.Round(IVA, 2);
            total = Math.Round(total, 2);

            var productAmount = new ProductAmountDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Subtotal = subtotal,
                IVA = IVA,
                Total = total
            };

            return Ok(productAmount);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();
           
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
