using MediatR;

namespace MessageQueue.Book.CQRS.Command.CreateBook
{
    public record CreateBookCommand: IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
