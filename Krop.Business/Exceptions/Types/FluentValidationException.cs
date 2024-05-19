namespace Krop.Business.Exceptions.Types
{
    public class FluentValidationException:Exception
    {
        public IEnumerable<string> Errors { get; }

        public FluentValidationException()
            : base()
        {
            Errors = Array.Empty<string>();
        }

        public FluentValidationException(string? message)
            : base(message)
        {
            Errors = Array.Empty<string>();
        }

        public FluentValidationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
            Errors = Array.Empty<string>();
        }

        public FluentValidationException(IEnumerable<string> errors)
            : base(BuildErrorMessage(errors))
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<string> errors)
        {
            return $"Validation failed: {string.Join(Environment.NewLine, errors)}";
        }
    }
}
