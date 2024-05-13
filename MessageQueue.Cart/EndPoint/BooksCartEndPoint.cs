using Carter;
using MapsterMapper;
using MediatR;
using MessageQueue.Cart.CQRS.Command.CreateBooksCart;
using MessageQueue.Cart.CQRS.Query.GetAllBooksCart;
using MessageQueue.Cart.CQRS.Query.GetBooksCart;
using MessageQueue.Cart.ViewModel;
using MessageQueue.Core.Dto;
using MessageQueue.Core.MessageBus;
using MessageQueue.Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MessageQueue.Cart.EndPoint
{
    public class BooksCartEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("GetAllBooksCart", GetAllBooksCart);

            app.MapGet("GetCart", GetCart);

            app.MapPost("CreateCart", CreateCart);
        }

        private async Task<IResult> GetAllBooksCart(ISender sender)
        {
            return Results.Ok(await sender.Send(new GetAllBooksCartQuery()));
        }

        private async Task<IResult> GetCart([FromQuery] Guid id, ISender sender)
        {
            return Results.Ok(await sender.Send(new GetBooksCartQuery(id)));
        }

        private async Task<IResult> CreateCart([FromBody] BooksCartCreateRequest request,
            ISender sender,
            IMapper mapper,
            IMessageBus bus,
            IOptions<BooksCartMessageBroker> options,
            IOptions<BooksCartLogBroker> logOptions)
        {
            var result = await sender.Send(mapper.Map<CreateBooksCartCommand>(request));

            bus.Publish(new BooksCartDto()
            {
                CartId = result.Id,
                List = request.Items.Select(s => new BooksCartItemDto() { BookId = s.BookId, Quantity = s.Quantity }).ToList()
            }, options.Value);
            bus.Publish($"Send from CreateCart:{DateTime.UtcNow}", logOptions.Value);
            return Results.Ok(result);
        }
    }
}
