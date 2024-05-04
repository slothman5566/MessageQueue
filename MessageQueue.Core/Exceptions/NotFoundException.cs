namespace MessageQueue.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base($"NotFound Exception: \"{message}\"")
        {
        }

    }
}
