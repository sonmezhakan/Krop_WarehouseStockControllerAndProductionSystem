using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Kategori adı en fazla 64 karakter olabilir. Boş olamaz!
    /// 
    /// </summary>
	public class Category:BaseEntity
	{
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
