using System.Reflection;
using Common.Infraestructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SiopjModule.Infraestructure.Database;

public class SiopjContext : BaseContext
{
    public static string Schema => "SIOPJ";    

    public SiopjContext() : base() { }

    public SiopjContext(DbContextOptions<SiopjContext> options, IMediator mediator) : base(options, mediator)
    { }

    public SiopjContext(DbContextOptions<SiopjContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .HasDefaultSchema(Schema);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
    }
}
