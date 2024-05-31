using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Supplier nesnesi Owned type özelleğini kullanarak Company, Contact, Address nesnelerinin propertylerini kendi bünyesini dahil ediyor.
    /// WebSite en fazla 255 karakter olabilir. Boş Olabilir.
    /// StockInput ile ilişkilidir.
    /// </summary>
    public class Supplier:BaseEntity
    {
        public Company Company { get; set; }
        public Contact? Contact { get; set; }
        public Address? Address { get; set; }

        public string? WebSite { get; set; }

        public virtual ICollection<StockInput> StockInputs { get; set; }
    }
}
