using FluentValidation;
using MediatR;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.CQRS.Command.CreateBooksCart
{
    public class CreateBooksCartCommand : IRequest<BooksCartCreateResponse>
    {
        public List<BooksCartItem> Items { get; set; }
    }


    public class CreateBooksCartCommandValidator : AbstractValidator<CreateBooksCartCommand>
    {
        public CreateBooksCartCommandValidator()
        {
            RuleFor(x => x.Items).NotNull().Must(x => x.Any()).WithMessage("Items is required");
            RuleFor(x => x.Items).Must(x => x.Any(y => y.Quantity <= 0)).WithMessage("Item Quantity must large than 0");
        }
    }
}
