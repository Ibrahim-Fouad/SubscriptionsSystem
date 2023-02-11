using System.Text.Json.Serialization;

namespace SubscriptionsSystem.Application.DTOs;

public record ErrorResultDto(int StatusCode, string Message,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? StackTrace = null);