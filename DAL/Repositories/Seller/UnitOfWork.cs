// Repositories/UnitOfWork.cs (cập nhật)
using Skynet_Ecommerce.DAL.Repositories.Seller;
using System;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IRepository<ProductVariant> ProductVariants { get; private set; }
        public IRepository<ProductImage> ProductImages { get; private set; }
        public IRepository<OrderDetail> OrderDetails { get; private set; }
        public IRepository<OrderStatusHistory> OrderStatusHistory { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
            ProductVariants = new Repository<ProductVariant>(_context);
            ProductImages = new Repository<ProductImage>(_context);
            OrderDetails = new Repository<OrderDetail>(_context);
            OrderStatusHistory = new Repository<OrderStatusHistory>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}