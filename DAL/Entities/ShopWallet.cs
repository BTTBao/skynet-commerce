// Entities/ShopWallet.cs
using System;
using System.Collections.Generic;

namespace Skynet_Ecommerce.DAL.Entities
{
    public class ShopWallet
    {
        public int WalletID { get; set; }
        public int ShopID { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalWithdrawn { get; set; }
        public DateTime LastUpdated { get; set; }

        // Navigation properties
        public virtual Shop Shop { get; set; }
        public virtual ICollection<WalletTransaction> Transactions { get; set; }
        public virtual ICollection<WithdrawalRequest> WithdrawalRequests { get; set; }
        public virtual ICollection<SettledOrder> SettledOrders { get; set; }
    }
}