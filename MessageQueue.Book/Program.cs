using MapsterMapper;
using MediatR;
using MessageQueue.Book.Configurtion;
using MessageQueue.Book.CQRS.Command.CreateBook;
using MessageQueue.Book.CQRS.Command.DeleteBook;
using MessageQueue.Book.CQRS.Command.UpdateBook;
using MessageQueue.Book.CQRS.Query.GetAllBooks;
using MessageQueue.Book.CQRS.Query.GetBook;
using MessageQueue.Book.Data;
using MessageQueue.Book.Repository;
using MessageQueue.Book.Service;
using MessageQueue.Book.ViewModel;
using MessageQueue.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddCacheConfiguration(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddHostedService<RabbitMqCartDirectConsumerService>();
builder.Services.AddHostedService<RabbitMqCartFanoutConsumerService>();
builder.Services.AddDbContextConfiguration(builder.Configuration);
builder.Services.AddMediatorConfiguration(Assembly.GetExecutingAssembly());
builder.Services.AddMapsterConfiguration(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMigration();
await app.SeedData();
app.UseHttpsRedirection();


app.MapGet("GetAllBooks", (ISender sender) =>
{
    return sender.Send(new GetAllBooksQuery());
});
app.MapGet("GetBook", ([FromQuery] Guid id, ISender sender) =>
{
    return sender.Send(new GetBookQuery(id));
});
app.MapPost("CreateBook", async ([FromBody] BookCreateView view, IMapper mapper, ISender sender) =>
{
    var book = mapper.Map<CreateBookCommand>(view);
    await sender.Send(book);
    return Results.Ok();
});

app.MapPatch("UpdateBook", async Task<IResult> ([FromBody] BookUpdateView view, IMapper mapper, ISender sender) =>
{
    var book = mapper.Map<UpdateBookCommand>(view);
    await sender.Send(book);
    return Results.Ok();
});

app.MapDelete("DeleteBook", async Task<IResult> ([FromQuery] Guid id, ISender sender) =>
{
    await sender.Send(new DeleteBookCommand(id));
    return Results.Ok();
});
app.Run();
