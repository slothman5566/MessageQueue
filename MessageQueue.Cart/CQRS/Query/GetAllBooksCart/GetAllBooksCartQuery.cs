using MediatR;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Query.GetAllBooksCart
{
    public class GetAllBooksCartQuery : IRequest<List<BooksCartView>>
    {
    }
}
