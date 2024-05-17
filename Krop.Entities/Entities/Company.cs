using System.ComponentModel.DataAnnotations.Schema;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// CompanyName en fazla 255 karakter olabilir. Boş olamaz!
    /// ContactName en fazla 255 karakter olabilir. Boş olabilir!
    /// ContactTitl en fazla 64 karakter olabilir. Boş olabilir.
    /// </summary>
    [NotMapped]
    public class Company
    {
        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
    }
}
