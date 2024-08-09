using SiopjModule.Application.Features.ProgramaOperaciones.DTO;

namespace SiopjModule.Application.Features.ProgramaOperaciones.Queries.GetAllProgramaOperacional;

public record GetAllProgramaOperacionalQuery() : IQuery<Result<List<ProgramaOperacionalDto>>>;
