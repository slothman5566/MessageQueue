using MediatR;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Query.GetBooksCart
{
    public record GetBooksCartQuery(Guid Id) : IRequest<BooksCartView?>
    {


    }
}
