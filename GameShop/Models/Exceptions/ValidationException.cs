namespace GameShop.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public string Type { get; } = string.Empty;
        public ValidationException()
        {
        }

        public ValidationException(string message, string type) : base(message)
        {
            Type = type;
        }

        public ValidationException(string message, string type, Exception innerException) : base(message, innerException)
        {
            Type = type;
        }
    }
}
