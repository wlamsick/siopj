namespace Common.Domain.SharedEntities;

public record AuditTrail
{
    public AuditTrail() { }    
    public string CreatedBy { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; }
    public string? LastUpdatedBy { get; private set; }
    public DateTime? LastUpdatedAt { get; private set; }

    public void Update(string? updatedBy = "unknown")
    {
        LastUpdatedBy = updatedBy;
        LastUpdatedAt = DateTime.UtcNow;
    }

    public static AuditTrail RegisterCreation(string createdBy) 
    => new()
    { CreatedBy = createdBy, CreatedAt = DateTime.UtcNow };

    public static AuditTrail RegisterUpdate(string? updatedBy = "unknown")
    => new()
    { LastUpdatedBy = updatedBy, LastUpdatedAt = DateTime.UtcNow };
}
