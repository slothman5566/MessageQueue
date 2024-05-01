using MediatR;
using MessageQueue.Book.Repository.UnitOfWork;

namespace MessageQueue.Book.CQRS.Query.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Model.Book>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<List<Model.Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BookRepository.GetAllAsync();
        }
    }
}
