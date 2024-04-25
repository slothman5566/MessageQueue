﻿namespace MessageQueue.Core.Data.Model
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
