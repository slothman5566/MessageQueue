using MediatR;

namespace MessageQueue.Book.CQRS.Query.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Model.Book>>
    {
    }
}
