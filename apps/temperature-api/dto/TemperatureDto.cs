using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace temperature_api.dto;

// Go SmartHome service expects JSON fields in snake_case but .NET by default returns camelCase fields.
public record TemperatureDto(
    [property: JsonPropertyName("value")] double Value,
    [property: JsonPropertyName("unit")] string Unit,
    [property: JsonPropertyName("timestamp")] DateTime Timestamp,
    [property: JsonPropertyName("location")] string? Location,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("sensor_id")] string? SensorId,
    [property: JsonPropertyName("sensor_type")] string SensorType,
    [property: JsonPropertyName("description")] string Description);