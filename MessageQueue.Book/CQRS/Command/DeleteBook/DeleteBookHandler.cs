using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;

namespace MessageQueue.Book.CQRS.Command.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetById(BookId.Of(request.Id));
            if (book == null)
            {
                throw new NullReferenceException();
            }
            await _unitOfWork.BookRepository.Remove(book);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
