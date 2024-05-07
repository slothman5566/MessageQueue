using Carter;
using MapsterMapper;
using MediatR;
using MessageQueue.Book.CQRS.Command.CreateBook;
using MessageQueue.Book.CQRS.Command.DeleteBook;
using MessageQueue.Book.CQRS.Command.UpdateBook;
using MessageQueue.Book.CQRS.Query.GetAllBooks;
using MessageQueue.Book.CQRS.Query.GetBook;
using MessageQueue.Book.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MessageQueue.Book.EndPoint
{
    public class BookEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("GetAllBooks", GetAllBook);

            app.MapGet("GetBook", GetBook);

            app.MapPost("CreateBook", CreateBook);

            app.MapPatch("UpdateBook", UpdateBook);

            app.MapDelete("DeleteBook", DeleteBook);
        }

        private async Task<IResult> GetAllBook(ISender sender)
        {
            return Results.Ok(await sender.Send(new GetAllBooksQuery()));
        }

        private async Task<IResult> GetBook([FromQuery] Guid id, ISender sender)
        {
            return Results.Ok(await sender.Send(new GetBookQuery(id)));
        }

        private async Task<IResult> CreateBook(BookCreateView request, IMapper mapper, ISender sender)
        {
            var book = mapper.Map<CreateBookCommand>(request);
            await sender.Send(book);
            return Results.Ok();
        }

        private async Task<IResult> UpdateBook(BookUpdateView request, IMapper mapper, ISender sender)
        {
            var book = mapper.Map<UpdateBookCommand>(request);
            await sender.Send(book);
            return Results.Ok();
        }
        private async Task<IResult> DeleteBook([FromQuery] Guid id, ISender sender)
        {
            await sender.Send(new DeleteBookCommand(id));
            return Results.Ok();
        }

    }
}
