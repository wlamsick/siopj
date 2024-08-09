using System.Text.Json;

namespace Common.Models;

public class ErrorResponse
{
    public ErrorResponse(Exception exception, int statusCode, string? traceId = null)
    {
        Status = statusCode;
        Title = "One or more application errors occurred.";
        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        TraceId = traceId;

        Errors.Add(exception.GetType().Name, new string[] { exception.Message });
    }

    public string Type { get; private set; }
    public string Title { get; private set; }
    public int Status { get; private set; }
    public string? TraceId { get; set; }


    public Dictionary<string, string[]> Errors { get; private set; } = new();

    public override string ToString()
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        //var details = new { };
        return JsonSerializer.Serialize(new
        {
            Type,
            Title,
            Status,
            TraceId,
            Errors
        }, options);
    }
}
