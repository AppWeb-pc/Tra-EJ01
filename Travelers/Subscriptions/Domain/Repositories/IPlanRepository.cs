using Travelers.Shared.Domain.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregate;

namespace Travelers.Subscriptions.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan> 
{
    Task<Plan?> GetPlanByName(string name);
    Task<Plan?> GetPlanById(long id);
    void DeletePlanAsync(Plan plan);
    void Update(Plan plan);
    Task<IEnumerable<Plan>> GetAllAsync();
    int CountDefaultPlans();
}