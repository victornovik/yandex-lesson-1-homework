using temperature_api.dto;

namespace temperature_api.endpoints;

public static class TemperatureEndpoints
{
    public static void MapTemperatureEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/temperature");

        // GET /temperature?location=Banya
        group.MapGet("/", (string location) => GenerateRandomTemperature(location: location));

        // GET /temperature/555
        group.MapGet("/{sensorId}", (string sensorId) => GenerateRandomTemperature(sensorId: sensorId));
    }

    public static TemperatureDto GenerateRandomTemperature(string? location = null, string? sensorId = null)
    {
        var t = Math.Round(18 + Random.Shared.NextDouble() * 10, 1);

        location ??= sensorId switch
        {
            "1" => "Living Room",
            "2" => "Bedroom",
            "3" => "Kitchen",
            _ => "Unknown"
        };

        sensorId ??= location switch
        {
            "Living Room" =>"1",
            "Bedroom" => "2",
            "Kitchen" => "3",
            _ => "0"
        };

        return new TemperatureDto(
            Value: t,
            Unit: "°C",
            Timestamp: DateTime.UtcNow,
            Location: location,
            Status: "Active",
            SensorId: sensorId,
            SensorType: "Temperature",
            Description: $"Temperature of {location}");
    }
}