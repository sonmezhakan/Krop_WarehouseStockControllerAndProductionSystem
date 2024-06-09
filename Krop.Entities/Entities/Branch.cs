using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Şube adı en fazla 255 karakter olabilir. Boş olamaz!
    /// EmployeeBranch, Stock, StockInput, StockTransfer, Production nesneleri ile ilişkilidir.
    /// </summary>
	public class Branch:BaseEntity
	{
        public string BranchName { get; set; }

        public Contact Contact { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Employee>  Employees { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StockInput> StockInputs { get; set; }
        public virtual ICollection<StockTransfer> SenderStockTransfers { get; set; }
        public virtual ICollection<StockTransfer> SentStockTransfers { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<ProductionStockExit> ProductionStockExits { get; set; }
        public virtual ICollection<ProductNotification> ProductNotifications { get; set; }

    }
}
