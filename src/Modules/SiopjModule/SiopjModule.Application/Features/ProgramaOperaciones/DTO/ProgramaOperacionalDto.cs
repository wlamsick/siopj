using SiopjModule.Domain.Entities;

namespace SiopjModule.Application.Features.ProgramaOperaciones.DTO;

public record ProgramaOperacionalDto : IMapFrom<ProgramaOperacional>
{
    public int NumeroAz { get; init; }
    public string IMO { get; init; } = default!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProgramaOperacional, ProgramaOperacionalDto>()
            .ForMember(d => d.NumeroAz, opt => opt.MapFrom(s => s.NumeroAZ))
            .ForMember(d => d.IMO, opt => opt.MapFrom(s => s.LineaNaviera));
    }
}
