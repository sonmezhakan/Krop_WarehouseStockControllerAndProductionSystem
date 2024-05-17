using Krop.Entities.Enums;
using Krop.Entities.Interfaces;

namespace Krop.Entities.Abstracts
{
	public abstract class BaseEntity : IEntity<Guid>
	{
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

	}
}
