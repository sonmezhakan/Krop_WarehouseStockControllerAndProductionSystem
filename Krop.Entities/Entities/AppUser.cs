using Krop.Entities.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace Krop.Entities.Entities
{
	/// <summary>
	/// Owned Entity
	/// Employee Tablosu ile ilişkilidir.
	/// </summary>
	public class AppUser: BaseAppUserEntity
	{
		public Address Address { get; set; }
        public Person Person { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<StockInput> StockInputs { get; set; }
    }
}
