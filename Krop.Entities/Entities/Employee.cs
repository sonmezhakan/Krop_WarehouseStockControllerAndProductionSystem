using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Abstract classtan gelen Id ignore edilip AppUserId Primary Key olarak tanımlanmıştır. 
    /// Başlama tarihi ve Çıkış Tarihi boş olabilir.
    /// Maaş boş olabilir.
    /// AppUser, Department, Branch, StockInput nesneleri ile ilişkilidir.
    /// </summary>
	public class Employee:BaseEntity
	{
        public Guid AppUserId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? BranchId { get; set; }

        public DateTime? StartDateOfWork { get; set; }
        public DateTime? EndDateOfWork { get; set; }
        public decimal? Salary { get; set; }
        public bool WorkingStatu {  get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Department Department { get; set; }
        public virtual Branch Branch { get; set; } 
    }
}
