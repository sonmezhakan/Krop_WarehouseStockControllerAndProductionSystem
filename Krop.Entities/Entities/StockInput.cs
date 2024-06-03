using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    public class StockInput:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid BranchId { get; set; }
        public Guid AppUserId { get; set; }
        public Guid? ProductionId { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime InputDate { get; set; }
        

        public virtual Product Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual Branch Branch{ get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Production? Production { get; set; }
    }
}
