using Carter;
using FluentValidation;
using MessageQueue.Book.Configurtion;
using MessageQueue.Book.Data;
using MessageQueue.Book.Repository;
using MessageQueue.Book.Service;
using MessageQueue.Core.Configuration;
using MessageQueue.Core.Exceptions.Handler;
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
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddExceptionHandler<BaseExceptionHandler>();
builder.Services.AddCarter();
builder.Services.AddControllers();


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
app.UseExceptionHandler(options => { });
app.MapCarter();

app.Run();
