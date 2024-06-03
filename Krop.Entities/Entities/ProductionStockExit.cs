using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    public class ProductionStockExit:BaseEntity
    {
        public Guid ProductionId { get; set; }
        public Guid ProductId { get; set; }
        public int QuantityExit { get; set; }
        public DateTime ExitDate { get; set; }

        public virtual Production Production { get; set; }
        public virtual Product Product { get; set; }
    }
}
