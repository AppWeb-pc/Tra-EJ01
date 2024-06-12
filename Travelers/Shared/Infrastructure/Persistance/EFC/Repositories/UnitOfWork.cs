using Travelers.Shared.Domain.Repositories;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Travelers.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}