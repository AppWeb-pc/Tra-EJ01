namespace Travelers.Shared.Domain.Repositories;
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
}