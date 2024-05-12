using MapsterMapper;
using MediatR;
using MessageQueue.Cart.Configuration;
using MessageQueue.Cart.CQRS.Command.CreateBooksCart;
using MessageQueue.Cart.CQRS.Query.GetAllBooksCart;
using MessageQueue.Cart.CQRS.Query.GetBooksCart;
using MessageQueue.Cart.Repository;
using MessageQueue.Cart.ViewModel;
using MessageQueue.Core.Configuration;
using MessageQueue.Core.Dto;
using MessageQueue.Core.MessageBus;
using MessageQueue.Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddCacheConfiguration(builder.Configuration);
builder.Services.AddMessageBrokerConfiguration(builder.Configuration);
builder.Services.AddDbContextConfiguration(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddMediatorConfiguration(Assembly.GetExecutingAssembly());
builder.Services.AddMapsterConfiguration(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("GetAllBooksCart", (ISender sender) =>
{
    return sender.Send(new GetAllBooksCartQuery());
});
app.MapGet("GetCart", ([FromQuery] Guid id, ISender sender) =>
{
    return sender.Send(new GetBooksCartQuery(id));
});

app.MapPost("CreateCart", async ([FromBody] BooksCartCreateRequest request, ISender sender, IMapper mapper, IMessageBus bus,
    IOptions<BooksCartMessageBroker> options, IOptions<BooksCartLogBroker> logOptions) =>
{
    var result = await sender.Send(mapper.Map<CreateBooksCartCommand>(request));

    bus.Publish(new BooksCartDto()
    {
        CartId = result.Id,
        List = request.Items.Select(s => new BooksCartItemDto() { BookId = s.BookId, Quantity = s.Quantity }).ToList()
    }, options.Value);
    bus.Publish($"Send from CreateCart:{DateTime.UtcNow}", logOptions.Value);
});
app.UseHttpsRedirection();

app.UseMigration();
app.Run();
