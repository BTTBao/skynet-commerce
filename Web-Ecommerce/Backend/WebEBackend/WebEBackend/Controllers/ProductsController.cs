using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEBackend.Models;

namespace WebEBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SkynetCommerceContext _context;

        public ProductsController(SkynetCommerceContext context)
        {
            _context = context;
        }

        // 1. GET: api/Products (Lấy toàn bộ sản phẩm)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Sử dụng Include để lấy thêm thông tin hình ảnh và danh mục nếu cần
            return await _context.Products
                .Include(p => p.ProductImages)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)   // Lấy ảnh
                .Include(p => p.ProductVariants) // Lấy biến thể (Size/Color) <--- THÊM DÒNG NÀY
                .Include(p => p.Category)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm" });

            return product;
        }

        // 3. POST: api/Products (Tạo mới sản phẩm)
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.CreatedAt = DateTime.Now; // Tự động gán ngày tạo
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // 4. PUT: api/Products/5 (Cập nhật sản phẩm)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // 5. DELETE: api/Products/5 (Xóa sản phẩm)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}