using MapsterMapper;
using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;

namespace MessageQueue.Book.CQRS.Command.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetById(BookId.Of(request.Id));
            if (book == null)
            {
                throw new NullReferenceException();
            }
            book = _mapper.Map(request, book);
            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
