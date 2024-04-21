namespace MessageQueue.Core.Options
{
    public class MessageQueueConnection
    {
        public static string Key => "MessageQueueConnection";
        public string Password { get; set; }

        public string UserName { get; set; }
        public string HostName { get; set; }
    }
}
