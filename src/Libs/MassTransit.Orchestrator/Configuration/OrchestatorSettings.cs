namespace MassTransit.Orchestrator.Configuration;

public record OrchestatorSettings
{
    public string Host { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? ConnectionName { get; set; } = "/";
}
