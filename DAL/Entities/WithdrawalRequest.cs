// Entities/WithdrawalRequest.cs
using System;

namespace Skynet_Ecommerce.DAL.Entities
{
    public class WithdrawalRequest
    {
        public int WithdrawalID { get; set; }
        public int WalletID { get; set; }
        public int ShopID { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected, Completed
        public DateTime RequestedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public int? ProcessedBy { get; set; }
        public string RejectionReason { get; set; }

        // Navigation properties
        public virtual ShopWallet Wallet { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual Account ProcessedByAccount { get; set; }
    }
}