// Entities/WalletTransaction.cs
using System;

namespace Skynet_Ecommerce.DAL.Entities
{
    public class WalletTransaction
    {
        public int TransactionID { get; set; }
        public int WalletID { get; set; }
        public string TransactionType { get; set; } // OrderPayment, Withdrawal, Refund, Adjustment
        public decimal Amount { get; set; }
        public decimal BalanceBefore { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Description { get; set; }
        public int? ReferenceID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual ShopWallet Wallet { get; set; }
    }
}