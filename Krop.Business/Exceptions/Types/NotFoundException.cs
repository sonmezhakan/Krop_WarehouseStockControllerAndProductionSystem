namespace Krop.Business.Exceptions.Types
{
    public class NotFoundException:Exception
    {
        public NotFoundException()
        {

        }
        public NotFoundException(string? message) : base(message)
        {

        }
    }
}
