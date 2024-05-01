using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MessageQueue.Book.CQRS.Command.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Model.Book()
            {
                Author = request.Author,
                Description = request.Description,
                Id = BookId.Of(Guid.NewGuid()),
                Title = request.Title,
                PublishDate = request.PublishDate,
            };
            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
