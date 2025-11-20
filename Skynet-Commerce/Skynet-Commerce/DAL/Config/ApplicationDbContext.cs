using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Skynet_Commerce.DAL.Entities
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChatAttachment> ChatAttachments { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatRoom> ChatRooms { get; set; }
        public virtual DbSet<FlashSaleProduct> FlashSaleProducts { get; set; }
        public virtual DbSet<FlashSale> FlashSales { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderGroup> OrderGroups { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderShippingInfo> OrderShippingInfoes { get; set; }
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ShippingPartner> ShippingPartners { get; set; }
        public virtual DbSet<ShopRegistration> ShopRegistrations { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.ChatMessages)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.ChatRooms)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.BuyerID);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.OrderGroups)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Shops)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Account)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Wishlists)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.ParentCategoryID);

            modelBuilder.Entity<FlashSaleProduct>()
                .Property(e => e.FlashSalePrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.SubTotal)
                .HasPrecision(23, 2);

            modelBuilder.Entity<OrderGroup>()
                .Property(e => e.TotalAmount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalAmount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<OrderShippingInfo>()
                .Property(e => e.ShippingFee)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CartItems)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Wishlists)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductVariant>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Shop>()
                .Property(e => e.RatingAverage)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Shop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Vouchers)
                .WithOptional(e => e.Shop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Voucher>()
                .Property(e => e.DiscountPercent)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Voucher>()
                .Property(e => e.MinOrderAmount)
                .HasPrecision(12, 2);
        }
    }
}
