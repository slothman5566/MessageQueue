using Hangfire;
using MediatR;
using Service.Request;
using Service;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHangfire(config => config.UseInMemoryStorage());

builder.Services.AddMediatRConfig();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseHangfireDashboard();
app.Run();
