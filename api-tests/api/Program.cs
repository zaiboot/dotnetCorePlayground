using Api.Routing;
using Api.Infra;
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
});

// Add services to the container.
builder.Services.RegisterDependencies();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.WebHost.UseUrls("http://localhost:5020");
var app = builder.Build();
app.MapRoutes();
app.Run();
