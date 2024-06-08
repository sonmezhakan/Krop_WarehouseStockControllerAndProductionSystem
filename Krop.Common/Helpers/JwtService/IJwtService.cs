using Krop.Entities.Entities;

namespace Krop.Common.Helpers.JwtService
{
    public interface IJwtService
    {
        Task<string> CreateToken(AppUser appUser, IList<string> roles);
    }
}
