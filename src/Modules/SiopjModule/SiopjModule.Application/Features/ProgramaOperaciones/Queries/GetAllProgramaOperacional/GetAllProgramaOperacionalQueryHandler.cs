using SiopjModule.Application.Features.ProgramaOperaciones.DTO;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Application.Features.ProgramaOperaciones.Queries.GetAllProgramaOperacional;

internal sealed class GetAllProgramaOperacionalQueryHandler
: IQueryHandler<GetAllProgramaOperacionalQuery, Result<List<ProgramaOperacionalDto>>>
{
    private readonly IProgramaOperacionalRepository repository;
    private readonly IMapper mapper;

    public GetAllProgramaOperacionalQueryHandler(
        IProgramaOperacionalRepository repository, 
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<Result<List<ProgramaOperacionalDto>>> Handle(GetAllProgramaOperacionalQuery request, CancellationToken cancellationToken)
    {
        var programa = await repository.GetAllAsync(cancellationToken);
        var programaDto = mapper.Map<List<ProgramaOperacionalDto>>(programa);
        return Result<List<ProgramaOperacionalDto>>.Success(programaDto);
    }
}
