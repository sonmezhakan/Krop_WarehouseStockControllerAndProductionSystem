using System.ComponentModel.DataAnnotations.Schema;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// 
    /// Email adresi en fazla 128 karakter olabilir.
    /// </summary>
    [NotMapped]
    public class Contact
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
