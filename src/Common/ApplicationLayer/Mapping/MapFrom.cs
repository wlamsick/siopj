namespace Common.Application.Mapping;

public abstract class MapFrom<T> : IMapFrom<T>
{
    public abstract void Mapping(MappingProfile profile);
}
