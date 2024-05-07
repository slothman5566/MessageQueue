using MediatR;
using MessageQueue.Book.ViewModel;

namespace MessageQueue.Book.CQRS.Query.GetBook
{
    public record GetBookQuery(Guid Id) : IRequest<BookView?>;
}
