using MessageQueue.Cart.Repository.Implement;
using MessageQueue.Cart.Repository.Interface;
using MessageQueue.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddCacheConfiguration(builder.Configuration);
builder.Services.AddScoped<IBooksCartRepository, BooksCartCacheRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("GetAllBooksCart", (IBooksCartRepository repo) =>
{
    return repo.GetAllBooksCart();
});
app.MapGet("GetCart", ([FromQuery] Guid id, IBooksCartRepository repo) =>
{
    return repo.GetCart(id);
});

app.MapPost("CreateCart", ([FromBody] MessageQueue.Cart.Model.BooksCart cart, IBooksCartRepository repo) =>
{
    cart.Id = Guid.NewGuid();
    cart.Items.ForEach(x => x.BooksCartId = cart.Id);
    cart.CreatedAt = DateTime.UtcNow;
    return repo.AddCart(cart);
});
app.UseHttpsRedirection();


app.Run();
