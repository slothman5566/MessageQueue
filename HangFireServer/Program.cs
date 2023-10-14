using Hangfire;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHangfire(config => config.UseInMemoryStorage());
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseHangfireDashboard();
app.Run();
