using MediatR;

namespace MessageQueue.Book.CQRS.Command.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
