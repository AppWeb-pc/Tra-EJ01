using Travelers.Shared.Domain.Repositories;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Travelers.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new Exception(e.Message);
        }
    } 
    
}