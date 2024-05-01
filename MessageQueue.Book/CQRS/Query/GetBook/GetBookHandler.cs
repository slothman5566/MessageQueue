using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;

namespace MessageQueue.Book.CQRS.Query.GetBook
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, Model.Book?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Model.Book?> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BookRepository.GetById(BookId.Of(request.Id));
        }
    }
}
