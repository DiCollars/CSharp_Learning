namespace Learnings.Text.Cleaner.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}
