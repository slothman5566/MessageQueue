using MapsterMapper;
using MediatR;
using MessageQueue.Cart.Repository.UnitOfWork;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Query.GetAllBooksCart
{
    public class GetAllBooksCartQueryHandler : IRequestHandler<GetAllBooksCartQuery, List<BooksCartView>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public GetAllBooksCartQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BooksCartView>> Handle(GetAllBooksCartQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BooksCartRepository.GetAllAsync();
            return _mapper.Map<List<BooksCartView>>(result);
        }
    }
}
