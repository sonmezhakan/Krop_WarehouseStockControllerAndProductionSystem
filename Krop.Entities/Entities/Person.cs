using System.ComponentModel.DataAnnotations.Schema;

namespace Krop.Entities.Entities
{
	/// <summary>
	/// Adı en fazla 128 karakter olabilir. Boş olamaz!
	/// Soyadı en fazla 128 karakter olabilir. Boş olamaz!
	/// Kimlik numarası en fazla 1 karakter olabilir. Boş olabilir!
	/// </summary>
	[NotMapped]
    public class Person
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? NationalNumber { get; set; }
    }
}