using MessageQueue.Book.Configurtion;
using MessageQueue.Book.Data;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository;
using MessageQueue.Book.Repository.Implement;
using MessageQueue.Book.Repository.Interface;
using MessageQueue.Book.Repository.UnitOfWork;
using MessageQueue.Book.Service;
using MessageQueue.Book.ViewModel;
using MessageQueue.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
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


app.MapGet("GetAllBooks", (IUnitOfWork uow) =>
{
    return uow.BookRepository.GetAllAsync();
});
app.MapGet("GetBook", ([FromQuery] Guid id, IUnitOfWork uow) =>
{
    return uow.BookRepository.GetById(BookId.Of(id));
});
app.MapPost("CreateBook", async ([FromBody] BookCreateView view, IUnitOfWork uow) =>
{
    var book = new Book()
    {
        Author = view.Author,
        Description = view.Description,
        Id = BookId.Of(Guid.NewGuid()),
        Title = view.Title,
        PublishDate = view.PublishDate,
    };
    await uow.BookRepository.Add(book);
    await uow.SaveChangeAsync();
    return Results.Ok();
});

app.MapPatch("UpdateBook", async Task<IResult> ([FromBody] BookUpdateView view, IUnitOfWork uow) =>
{
    var book = await uow.BookRepository.GetById(BookId.Of(view.Id));
    if (book == null)
    {
        throw new NullReferenceException();
    }
    book.Author = view.Author;
    book.Description = view.Description;
    book.PublishDate = view.PublishDate;
    book.Title = view.Title;
    await uow.BookRepository.Update(book);
    await uow.SaveChangeAsync();
    return Results.Ok();
});

app.MapDelete("DeleteBook", async Task<IResult> ([FromQuery] Guid id, IUnitOfWork uow) =>
{
    var book = await uow.BookRepository.GetById(BookId.Of(id));
    if (book == null)
    {
        throw new NullReferenceException();
    }
    await uow.BookRepository.Remove(book);
    await uow.SaveChangeAsync();
    return Results.Ok();
});
app.Run();
