using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Departman Adı en fazla 255 karakter olabilir. Boş olamaz!
    /// Açıklama en fazla 255 karakter olabilir. Boş olabilir!
    /// EmployeeDepartment nesnesi ile ilişkilidir.
    /// </summary>
	public class Department:BaseEntity
	{
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
