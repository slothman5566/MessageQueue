using MapsterMapper;
using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;
using MessageQueue.Book.ViewModel;

namespace MessageQueue.Book.CQRS.Query.GetBook
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, BookView?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookView?> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetById(BookId.Of(request.Id));
            return _mapper.Map<BookView?>(result);
        }
    }
}
