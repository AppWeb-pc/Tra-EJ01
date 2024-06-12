using Microsoft.EntityFrameworkCore;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;
using Travelers.Shared.Infrastructure.Persistence.EFC.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregate;
using Travelers.Subscriptions.Domain.Repositories;

namespace Travelers.Subscriptions.Infrastructure.Persistence.EFC;

public class PlanRepository(AppDbContext context) : BaseRepository<Plan>(context), IPlanRepository
{
    public async Task<Plan?> GetPlanByName(string name)
    {
        return await context.Set<Plan>().FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Plan?> GetPlanById(long id)
    {
        return await context.Set<Plan>().FindAsync(id);
    }

    public void DeletePlanAsync(Plan plan)
    {
        context.Set<Plan>().Remove(plan);
    }
    
    public void Update(Plan plan)
    {
        context.Set<Plan>().Update(plan);
    }

    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await context.Set<Plan>().ToListAsync();
    }

    public int CountDefaultPlans()
    {
        return  context.Set<Plan>().Count(x => x.Default == 1);
    }
}