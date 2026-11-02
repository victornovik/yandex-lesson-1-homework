using temperature_api.endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

var app = builder.Build();
app.MapTemperatureEndpoints();
app.Run();