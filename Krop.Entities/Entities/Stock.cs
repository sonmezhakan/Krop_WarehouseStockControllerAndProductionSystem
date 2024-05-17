using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// BranchId ve ProductId Composite Key olarak tanımlanmıştır.
    /// Branch ve Product nesneleri ile ilişki kurulmuştur.
    /// </summary>
	public class Stock:BaseEntity
	{
        public Guid BranchId { get; set; }
        public Guid ProductId { get; set; }
        public int UnitsInStock  { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}
