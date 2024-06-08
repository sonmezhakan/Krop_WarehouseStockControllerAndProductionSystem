namespace Krop.Business.Exceptions.Types
{
    public class AuthorizationException:Exception
    {
        public AuthorizationException()
        {

        }
        public AuthorizationException(string? message) : base(message)
        {

        }
    }
}
