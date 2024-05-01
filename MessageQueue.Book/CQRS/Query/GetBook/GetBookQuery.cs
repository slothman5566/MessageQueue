using MediatR;

namespace MessageQueue.Book.CQRS.Query.GetBook
{
    public record GetBookQuery(Guid Id) : IRequest<Model.Book?>;
}
