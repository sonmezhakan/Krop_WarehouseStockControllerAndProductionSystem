using Krop.Entities.Abstracts;
using Krop.Entities.Enums;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Customer Nesnesi Owned type özelliğini kullanarak Company,Contact,Address nesnelerinin propertylerini kendi bünyesine dahil ederek kullanmaktadır.
    /// </summary>
    public class Customer:BaseEntity
    {
        public Company Company { get; set; }
        public Contact? Contact { get; set; }
        public Address? Address { get; set; }

        public InvoiceEnum Invoice { get; set; } = InvoiceEnum.Bireysel;
    }
}
