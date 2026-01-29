﻿using Microsoft.AspNetCore.Mvc;
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

        // --- 1. API LẤY DANH SÁCH (Tích hợp Tìm kiếm, Lọc, Sắp xếp) ---
        // Hàm này cân tất cả các trường hợp: Lấy hết, lấy theo tên, lấy theo giá...
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId, // 1. Sửa từ string? category thành int? categoryId
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sort)
        {
            // Bắt đầu chuỗi truy vấn
            var query = _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductVariants)
                .Include(p => p.Category)
                .Include(p => p.Shop)
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            // --- C. LỌC THEO GIÁ ---
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price.HasValue && p.Price.Value >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price.HasValue && p.Price.Value <= maxPrice.Value);
            }

            // --- D. SẮP XẾP ---
            switch (sort)
            {
                case "price_asc": // Giá tăng dần
                    query = query.OrderBy(p => p.Price);
                    break;
                case "price_desc": // Giá giảm dần
                    query = query.OrderByDescending(p => p.Price);
                    break;
                case "best_sell": // Bán chạy nhất
                    query = query.OrderByDescending(p => p.SoldCount);
                    break;
                case "newest": // Mới nhất (Mặc định)
                default:
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
            }

            return await query.ToListAsync();
        }

        // --- ĐÃ XÓA HÀM GetProducts() KHÔNG THAM SỐ Ở ĐÂY ĐỂ TRÁNH LỖI ---

        // --- 2. CHI TIẾT SẢN PHẨM ---
        // GET: api/Products/5

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductVariants)
                .Include(p => p.Category)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null) return NotFound(new { message = "Không tìm thấy sản phẩm" });
            return product;

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