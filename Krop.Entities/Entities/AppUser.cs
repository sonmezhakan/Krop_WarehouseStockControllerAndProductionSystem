using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Owned Entity
    /// Employee,StockInput,StockTransfer, Production Tablosu ile ilişkilidir.
    /// </summary>
    public class AppUser: BaseAppUserEntity
	{
		public Address Address { get; set; }
        public Person Person { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<StockInput> StockInputs { get; set; }
        public virtual ICollection<StockTransfer> StockTransfers { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<ProductionStockExit> ProductionStockExits { get; set; }
    }
}
