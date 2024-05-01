using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MessageQueue.Book.CQRS.Command.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetById(BookId.Of(request.Id));
            if (book == null)
            {
                throw new NullReferenceException();
            }
            book.Author = request.Author;
            book.Description = request.Description;
            book.PublishDate = request.PublishDate;
            book.Title = request.Title;
            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
