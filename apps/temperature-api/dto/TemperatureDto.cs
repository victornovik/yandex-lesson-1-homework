using System.ComponentModel.DataAnnotations;

namespace temperature_api.dto;

public record TemperatureDto(
    [Range(-40.0, 40.0)] double value,
    string unit,
    DateTime timestamp,
    string location,
    string status,
    string sensorId,
    string sensorType,
    string description);