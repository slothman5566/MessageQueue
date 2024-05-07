using MapsterMapper;
using MediatR;
using MessageQueue.Book.Repository.UnitOfWork;
using MessageQueue.Book.ViewModel;

namespace MessageQueue.Book.CQRS.Query.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookView>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BookView>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var list =await  _unitOfWork.BookRepository.GetAllAsync();
            return _mapper.Map<List<BookView>>(list);
        }
    }
}
