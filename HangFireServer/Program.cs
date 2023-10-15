using Hangfire;
using Service;
using Service.Request;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHangfire(config => config.UseInMemoryStorage()
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
);

builder.Services.AddHangfireServer(options =>
{
    options.WorkerCount = 1;
    options.Activator = new HangfireJobActivator(builder.Services.BuildServiceProvider());

});
builder.Services.AddScoped<IEventQueueService, EventQueueService>();
builder.Services.AddMediatRConfig();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseHangfireDashboard();
app.Run();
