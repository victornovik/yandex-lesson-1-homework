using temperature_api.dto;

namespace temperature_api.endpoints;

public static class TemperatureEndpoints
{
    public static void MapTemperatureEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/temperature");
        group.MapGet("/", (string location) => GenerateRandomTemperatureDto(location: location));
        group.MapGet("/{sensorId}", (string sensorId) => GenerateRandomTemperatureDto(sensorId: sensorId));
    }

    public static TemperatureDto GenerateRandomTemperatureDto(string? location = null, string? sensorId = null)
    {
        const double min = -40.0;
        const double max = 40.0;
        var t = Math.Round(min + Random.Shared.NextDouble() * (max - min), 1);

        return new TemperatureDto(t, "Celsius", DateTime.UtcNow, location, "Active", sensorId, "Thermometer", "Temperature measurement");
    }
}