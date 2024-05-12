using MapsterMapper;
using MediatR;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.UnitOfWork;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Query.GetBooksCart
{
    public class GetBooksCartQueryHandler : IRequestHandler<GetBooksCartQuery, BooksCartView?>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetBooksCartQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BooksCartView?> Handle(GetBooksCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BooksCartRepository.GetById(BooksCartId.Of(request.Id));
            return _mapper.Map<BooksCartView>(result);
        }
    }
}
