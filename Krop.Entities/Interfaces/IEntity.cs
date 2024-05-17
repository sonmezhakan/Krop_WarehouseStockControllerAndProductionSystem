using Krop.Entities.Enums;

namespace Krop.Entities.Interfaces
{
	public interface IEntity<T>
	{
        public T Id { get; set; }

    }
}
