namespace MessageQueue.Core.Options
{
    public class BaseMessageBroker
    {
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }

        public string Queue {  get; set; }

    }

    public class BooksCartMessageBroker : BaseMessageBroker
    {
        public static string Key => nameof(BooksCartMessageBroker);
    }
    public class BooksCartLogBroker : BaseMessageBroker
    {
        public static string Key => nameof(BooksCartLogBroker);
    }
}
