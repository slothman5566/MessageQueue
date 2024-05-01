using MediatR;

namespace MessageQueue.Book.CQRS.Command.DeleteBook
{
    public record DeleteBookCommand(Guid Id) : IRequest
    {
    }
}
