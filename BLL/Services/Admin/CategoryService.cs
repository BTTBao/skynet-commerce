using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class CategoryService
    {
        public List<CategoryViewModel> GetAllCategories()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = from c in db.Categories
                            orderby c.CategoryID ascending
                            select new CategoryViewModel
                            {
                                CategoryID = c.CategoryID,
                                CategoryName = c.CategoryName,
                                TotalProducts = c.Products.Count(),
                                TotalSubCategories = c.Categories1.Count()
                            };
                return query.ToList();
            }
        }
        // 2. Lấy chi tiết 1 danh mục để Sửa
        public Category GetCategoryById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categories.FirstOrDefault(c => c.CategoryID == id);
            }
        }

        // 3. Lấy danh sách danh mục cha (để đổ vào ComboBox)
        public List<Category> GetParentCategories()
        {
            using (var db = new ApplicationDbContext())
            {
                // Lấy id và tên để hiển thị, loại bỏ danh mục con quá sâu nếu cần
                return db.Categories.OrderBy(c => c.CategoryName).ToList();
            }
        }

        // 4. Thêm mới
        public void AddCategory(string name, int? parentId)
        {
            using (var db = new ApplicationDbContext())
            {
                var cat = new Category
                {
                    CategoryName = name,
                    ParentCategoryID = parentId
                };
                db.Categories.Add(cat);
                db.SaveChanges();
            }
        }

        // 5. Cập nhật
        public void UpdateCategory(int id, string name, int? parentId)
        {
            using (var db = new ApplicationDbContext())
            {
                var cat = db.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (cat == null) throw new Exception("Danh mục không tồn tại.");

                // Chống vòng lặp: Danh mục cha không thể là chính nó
                if (parentId == id) throw new Exception("Danh mục cha không thể là chính nó.");

                cat.CategoryName = name;
                cat.ParentCategoryID = parentId;
                db.SaveChanges();
            }
        }

        // 6. Xóa (Có kiểm tra ràng buộc)
        public void DeleteCategory(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var cat = db.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (cat == null) throw new Exception("Danh mục không tồn tại.");

                // Kiểm tra ràng buộc: Có sản phẩm không?
                if (cat.Products.Count > 0)
                    throw new Exception($"Danh mục này đang chứa {cat.Products.Count} sản phẩm. Hãy chuyển sản phẩm sang danh mục khác trước khi xóa.");

                // Kiểm tra ràng buộc: Có danh mục con không?
                if (cat.Categories1.Count > 0)
                    throw new Exception("Danh mục này đang chứa các danh mục con. Hãy xóa hoặc di chuyển danh mục con trước.");

                db.Categories.Remove(cat);
                db.SaveChanges();
            }
        }
    }
}
