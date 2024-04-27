using MessageQueue.Core.Model;

namespace MessageQueue.Book.Model
{
    public record BookId
    {
        public Guid Value { get; }
        private BookId(Guid value) => Value = value;
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
