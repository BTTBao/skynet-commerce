// Repositories/IUnitOfWork.cs
using System;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IRepository<ProductVariant> ProductVariants { get; }
        IRepository<ProductImage> ProductImages { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        IRepository<OrderStatusHistory> OrderStatusHistory { get; }

        int Complete();
    }
}