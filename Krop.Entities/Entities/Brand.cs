using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Marka Adı en fazla 255 karakter olabilir. Boş Olamaz.
    /// Brand nesnesi Owned type özelliğini kullanarak Contact nesnesinin propertylerini kendi bünyesine dahil edilerek tanımlanmıştır.
    /// Product nesnesi ile ilişkilidir.
    /// </summary>
    public class Brand:BaseEntity
    {
        public string BrandName { get; set; }

        public Contact? Contact { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
