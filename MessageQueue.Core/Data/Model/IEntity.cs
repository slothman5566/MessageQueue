using System.ComponentModel.DataAnnotations;

namespace MessageQueue.Core.Data.Model
{
    public interface IEntity
    {
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get;set; }
    }

    public interface IEntity<T>: IEntity
    {
        T Id { get; set; }
    }
}
