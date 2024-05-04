using FluentValidation;
using MediatR;

namespace MessageQueue.Book.CQRS.Command.CreateBook
{
    public record CreateBookCommand : IRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }
    }

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Author).NotNull().NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.PublishDate).Must(x => x < DateTime.UtcNow).WithMessage("PublishDate Must LessThan Now");
        }
    }
}
