using MessageQueue.Cart.Configuration;
using MessageQueue.Cart.Model;
using MessageQueue.Cart.Repository.Implement;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Configuration;
using MessageQueue.Core.Dto;
using MessageQueue.Core.MessageBus;
using MessageQueue.Core.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddCacheConfiguration(builder.Configuration);
builder.Services.AddMessageBrokerConfiguration(builder.Configuration);
builder.Services.AddScoped<IBooksCartRepository, BooksCartRepository>();
builder.Services.Decorate<IBooksCartRepository, BooksCartCacheRepository>();
builder.Services.AddDbContextConfiguration(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("GetAllBooksCart", (IBooksCartRepository repo) =>
{
    return repo.GetAllAsync();
});
app.MapGet("GetCart", ([FromQuery] Guid id, IBooksCartRepository repo) =>
{
    return repo.GetById(BooksCartId.Of(id));
});

app.MapPost("CreateCart", ([FromBody] BooksCart cart, IBooksCartRepository repo, IMessageBus bus,
    IOptions<BooksCartMessageBroker> options, IOptions<BooksCartLogBroker> logOptions) =>
{
    cart.Id = BooksCartId.Of(Guid.NewGuid());
    cart.Items.ForEach(x => x.BooksCartId = cart.Id);
    cart.CreatedAt = DateTime.UtcNow;
    bus.Publish(new BooksCartDto()
    {
        CartId = cart.Id.Value,
        List = cart.Items.Select(s => new BooksCartItemDto() { BookId = s.BookId, Quantity = s.Quantity }).ToList()
    }, options.Value);
    bus.Publish($"Send from CreateCart:{DateTime.UtcNow}", logOptions.Value);
    return repo.Add(cart);
});
app.UseHttpsRedirection();

app.UseMigration();
app.Run();
