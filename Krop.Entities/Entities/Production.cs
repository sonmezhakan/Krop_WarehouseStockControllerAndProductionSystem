using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    public class Production:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
        public Guid AppUserId { get; set; }
        public int ProductionQuantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? Description { get; set; }

        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual StockInput StockInput { get; set; }
        public virtual ICollection<ProductionStockExit> ProductionStockExits { get; set; }
    }
}
