using MessageQueue.Book.Configurtion;
using MessageQueue.Book.Data;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.Implement;
using MessageQueue.Book.Repository.Interface;
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
builder.Services.AddScoped<IBookRepository, BookCacheRepository>();

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


app.MapGet("GetAllBooks", (IBookRepository repo) =>
{
    return repo.GetAllAsync();
});
app.MapGet("GetBook", ([FromQuery] Guid id, IBookRepository repo) =>
{
    return repo.GetById(BookId.Of(id));
});
app.MapPost("CreateBook",  ([FromBody] BookCreateView view, IBookRepository repo) =>
{
    var book = new Book()
    {
        Author = view.Author,
        Description = view.Description,
        Id = BookId.Of(Guid.NewGuid()),
        Title = view.Title,
        PublishDate = view.PublishDate,
    };
    return  repo.Add(book);
});

app.MapPatch("UpdateBook", async Task<IResult>([FromBody] BookUpdateView view, IBookRepository repo) =>
{
    var book = await repo.GetById(BookId.Of(view.Id));
    if (book == null)
    {
        throw new NullReferenceException();
    }
    book.Author = view.Author;
    book.Description = view.Description;
    book.PublishDate = view.PublishDate;
    book.Title = view.Title;
      await repo.Update(book);
    return Results.Ok();
});
app.Run();
