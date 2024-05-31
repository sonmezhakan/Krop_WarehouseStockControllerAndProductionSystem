﻿using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    /// <summary>
    /// Şube adı en fazla 255 karakter olabilir. Boş olamaz!
    /// EmployeeBranch, Stock nesneleri ile ilişkilidir.
    /// Ayrıca Branch nesnesi Owned Type özelliğini kullanarak Address nesnesindeki tüm propertyleri kendisi de kullanabilmektedir.
    /// </summary>
	public class Branch:BaseEntity
	{
        public string BranchName { get; set; }

        public Contact Contact { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Employee>  Employees { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StockInput> StockInputs { get; set; }
    }
}
