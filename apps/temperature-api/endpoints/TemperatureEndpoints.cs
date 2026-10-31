using temperature_api.dto;

namespace temperature_api.endpoints;

public static class TemperatureEndpoints
{
    public static void MapTemperatureEndpoints(this WebApplication app)
    {
        app.MapGet("/temperature", (string location) =>
        {
            const double min = -40.0;
            const double max = 40.0;
            var t = Math.Round(min + Random.Shared.NextDouble() * (max - min), 1);

            var dto = new TemperatureDto(t, "Celsius", DateTime.UtcNow, location, "Active", "1", "Thermometer", "Temperature sensor");
            return dto;

        }).WithName("temperature");
    }
}