using Krop.Entities.Enums;
using Krop.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Krop.Entities.Abstracts
{
	/// <summary>
	/// Kullanıcılar için Identity kütüphanesini kullanacağımızdan ötürü AppUser classına inheritance kurallarından ötürü hem BaseClass hem de Identity classlarını inherit edemiyoruz. O yüzden bir başka soyut class oluşturup gerekli olan Identity classı ve IEntity interface i dahil implement edilmiştir.
	/// Ayrıca Identity kütüphanesinde Id tanımlandığı için IEntity de implement edilmesen gereken Id'yi tekrardan tanımlamak zorunda kalmadık.
	/// </summary>
	public abstract class BaseAppUserEntity:IdentityUser<Guid>,IEntity<Guid>
	{

	}
}
