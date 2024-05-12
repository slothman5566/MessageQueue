using MediatR;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Command.CreateBooksCart
{
    public class CreateBooksCartCommand : IRequest<BooksCartCreateResponse>
    {
        public List<BooksCartItem> Items { get; set; }
    }
}
