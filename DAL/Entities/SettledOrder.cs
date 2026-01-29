// Entities/SettledOrder.cs
using System;

namespace Skynet_Ecommerce.DAL.Entities
{
    public class SettledOrder
    {
        public int SettlementID { get; set; }
        public int OrderID { get; set; }
        public int ShopID { get; set; }
        public int WalletID { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime SettledAt { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ShopWallet Wallet { get; set; }
    }
}