using MapsterMapper;
using MediatR;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MessageQueue.Book.CQRS.Command.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Model.Book>(request);
            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
