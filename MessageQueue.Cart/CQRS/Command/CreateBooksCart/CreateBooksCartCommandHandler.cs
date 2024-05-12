using MediatR;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.UnitOfWork;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Command.CreateBooksCart
{
    public class CreateBooksCartCommandHandler : IRequestHandler<CreateBooksCartCommand, BooksCartCreateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBooksCartCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BooksCartCreateResponse> Handle(CreateBooksCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new BooksCart()
            {
                Id = BooksCartId.Of(Guid.NewGuid()),
                Items = request.Items,
            };
            await _unitOfWork.BooksCartRepository.Add(cart);
            await _unitOfWork.SaveChangeAsync();
            return new BooksCartCreateResponse() { Id = cart.Id.Value };
        }
    }
}
