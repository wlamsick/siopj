using System.Linq.Expressions;

namespace Common.Domain.SeedWork;

public interface IRepository<TEntity> : IQueryableRepository<TEntity>, IWriteableRepository<TEntity> where TEntity : class, IEntity
{

}
