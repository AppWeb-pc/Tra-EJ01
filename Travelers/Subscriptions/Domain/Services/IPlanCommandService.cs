using Travelers.Subscriptions.Domain.Model.Aggregate;
using Travelers.Subscriptions.Domain.Model.Commands;

namespace Travelers.Subscriptions.Domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand command);
    Task<IEnumerable<Plan>> GetAllAsync();
    Task<Plan?> Handle(UpdatePlanCommand command);
    Task DeletePlanAsync(DeletePlanCommand command);
}