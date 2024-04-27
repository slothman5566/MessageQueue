using MessageQueue.Book.Configurtion;
using MessageQueue.Book.Data;
using MessageQueue.Book.Model;
using MessageQueue.Book.Repository.Implement;
using MessageQueue.Book.Repository.Interface;
using MessageQueue.Book.Service;
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
app.Run();
