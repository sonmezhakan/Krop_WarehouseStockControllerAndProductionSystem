using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Ürün adı en fazla 255 karakter olabilir. Boş olamaz!
    /// Ürün kodu en fazla 255 karakter olabilir. Boş olamaz!
    /// Kritik Miktar ve Fiyat verilmez ise default olarak 0 değeri veriliyor. Boş olabilir!
    /// Açıklama en fazla 1000 karakter olabilir. Boş olabilir!
    /// </summary>
	public class Product:BaseEntity
	{
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int CriticalStock { get; set; }
        public string? Description { get; set; }
        public Guid? Image { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductReceipt> ProductReceipts { get; set; }
        public virtual ICollection<StockInput>  StockInputs { get; set; }
        public virtual ICollection<StockTransfer> StockTransfers { get; set; }
        public virtual ICollection<Production> Productions { get; set; }
        public virtual ICollection<ProductionStockExit> ProductionStockExits { get; set; }
        public virtual ICollection<ProductNotification> ProductNotifications { get; set; }
    }
	
}
