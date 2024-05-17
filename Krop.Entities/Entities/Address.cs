using System.ComponentModel.DataAnnotations.Schema;

namespace Krop.Entities.Entities
{
	/// <summary>
	/// Ülke en fazla 64 karakter olabilir. Boş olabilir!
	/// Şehir en fazla 64 karakter olabilir. Boş olabilir!
	/// Adres en fazla 255 karakter olabilir. Boş olabilir!
	/// </summary>
	[NotMapped]
	public class Address
	{
		public string? Country { get; set; }
		public string? City { get; set; }
		public string? Addres { get; set; }
	}
}
