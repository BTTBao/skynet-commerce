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

        // --- 1. API LẤY DANH SÁCH (Đã sửa lỗi) ---
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sort)
        {
            var query = _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Reviews)
                .Include(p => p.Shop)
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(p => p.Name.Contains(keyword));
            
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price.HasValue && p.Price.Value >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price.HasValue && p.Price.Value <= maxPrice.Value);

            switch (sort)
            {
                case "price_asc": query = query.OrderBy(p => p.Price); break;
                case "price_desc": query = query.OrderByDescending(p => p.Price); break;
                case "best_sell": query = query.OrderByDescending(p => p.SoldCount); break;
                case "newest": 
                default: query = query.OrderByDescending(p => p.CreatedAt); break;
            }

            var result = await query.Select(p => new
            {
                p.ProductId,
                p.Name,
                p.Price,
                p.Description,
                p.SoldCount,
                p.CategoryId,
                
                // ✅ SỬA 1: Đổi ImageURL -> ImageUrl (hoặc kiểm tra lại Model ProductImage của bạn)
                Img = p.ProductImages.Where(i => i.IsPrimary == true).Select(i => i.ImageUrl).FirstOrDefault() 
                      ?? p.ProductImages.Select(i => i.ImageUrl).FirstOrDefault(),

                // ✅ SỬA 2: Xử lý Rating. Thêm '?? 0' để tránh lỗi null và đảm bảo kiểu dữ liệu double
                Rating = p.Reviews.Any() ? Math.Round(p.Reviews.Average(r => r.Rating ?? 0), 1) : 0,
                
                ReviewCount = p.Reviews.Count()
            })
            .ToListAsync();

            return Ok(result);
        }

        // --- 2. CHI TIẾT SẢN PHẨM (Đã sửa lỗi) ---
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new 
                {
                    p.ProductId,
                    p.Name,
                    p.Price,
                    p.Description,
                    p.SoldCount,
                    p.CategoryId,
                    p.StockQuantity,
                    
                    // ✅ SỬA 3: Đổi p.Category.Name -> p.Category.CategoryName (Nếu lỗi, hãy kiểm tra file Model Category.cs)
                    CategoryName = p.Category != null ? p.Category.CategoryName : "",
                    
                    ShopName = p.Shop != null ? p.Shop.ShopName : "",
                    ShopId = p.ShopId,

                    // ✅ SỬA 4: Đổi ImageURL -> ImageUrl
                    Images = p.ProductImages.Select(i => new { i.ImageId, i.ImageUrl, i.IsPrimary }).ToList(),
                    
                    Variants = p.ProductVariants.Select(v => new { v.VariantId, v.Color, v.Size, v.Price, v.StockQuantity }).ToList(),

                    // ✅ SỬA 5: Xử lý Rating tương tự bên trên
                    Rating = p.Reviews.Any() ? Math.Round(p.Reviews.Average(r => r.Rating ?? 0), 1) : 0,
                    ReviewCount = p.Reviews.Count()
                })
                .FirstOrDefaultAsync();

            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm" });

            return Ok(product);
        }

        // --- 3. TẠO MỚI ---
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.CreatedAt = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // --- 4. CẬP NHẬT ---
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();

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

        // --- 5. XÓA ---
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