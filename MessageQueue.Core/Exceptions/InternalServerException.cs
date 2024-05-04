namespace MessageQueue.Core.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base($"InternalServer Exception: \"{message}\"")
        {
        }

        public InternalServerException(string message, string details) : base($"InternalServer Exception: \"{message}\"")
        {
            Details = details;
        }

        public string? Details { get; }
    }
}
