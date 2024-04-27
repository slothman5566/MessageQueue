using MessageQueue.Core.Model;
using System.Text.Json.Serialization;

namespace MessageQueue.Book.Model
{


    public record BookId : EntityId<Guid>
    {
        [JsonConstructor]
        protected BookId(Guid value) : base(value)
        {

        }

        public static BookId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new Exception("BookId cannot be empty.");
            }
            return new BookId(value);
        }
    }

    public class Book : Entity<BookId>
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
