using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    public class ProductReceipt:BaseEntity
    {
        public Guid ProduceProductId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
