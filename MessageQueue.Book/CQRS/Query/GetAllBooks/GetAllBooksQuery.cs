using MediatR;
using MessageQueue.Book.ViewModel;

namespace MessageQueue.Book.CQRS.Query.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookView>>
    {
    }
}
