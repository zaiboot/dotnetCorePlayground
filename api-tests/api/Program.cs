using Api.Routing;
using Api.Infra;
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
});

// Add services to the container.
builder.Services.RegisterDependencies();
builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// removing for the moment
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://localhost:5020");
var app = builder.Build();
app.MapRoutes();
app.Run();
