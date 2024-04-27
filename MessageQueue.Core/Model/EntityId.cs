namespace MessageQueue.Core.Model
{
    public abstract record EntityId<T>
    {
        public T Value { get; protected set; }

        protected EntityId(T value)
        {
            Value = value;
        }
    }
}
