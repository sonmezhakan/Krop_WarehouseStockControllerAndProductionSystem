using Krop.Entities.Abstracts;
using Krop.Entities.Enums;

namespace Krop.Entities.Entities
{
    public class StockTransfer:BaseEntity
    {
        public Guid SenderBranchId { get; set; }
        public Guid SentBranchId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TransactorAppUserId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime TransferDate { get; set; }

        public Branch SenderBranch { get; set; }
        public Branch SentBranch { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
