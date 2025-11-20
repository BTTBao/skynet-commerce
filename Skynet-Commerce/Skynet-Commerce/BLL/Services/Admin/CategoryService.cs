using Skynet_Commerce.BLL.Models.Admin;
using Skynet_Commerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynet_Commerce.BLL.Services.Admin
{
    public class CategoryService
    {
        public List<CategoryViewModel> GetAllCategories()
        {
            using (var db = new ApplicationDbContext())
            {
                // Truy vấn LINQ
                var query = from c in db.Categories
                                // Sắp xếp theo tên hoặc ID tùy bạn
                            orderby c.CategoryID ascending
                            select new CategoryViewModel
                            {
                                CategoryID = c.CategoryID,
                                CategoryName = c.CategoryName,

                                // Đếm số sản phẩm thuộc danh mục này
                                TotalProducts = c.Products.Count(),

                                // Đếm số danh mục con (Dựa trên quan hệ Categories1 trong Entity bạn gửi)
                                TotalSubCategories = c.Categories1.Count()
                            };

                return query.ToList();
            }
        }
    }
}
