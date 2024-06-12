using Travelers.Subscriptions.Domain.Model.Aggregate;
using Travelers.Subscriptions.Interface.REST.Resources;

namespace Travelers.Subscriptions.Interface.REST.Transform;

public class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan plan)
    {
        return new PlanResource(plan.Id, plan.Name, plan.MaxUsers, plan.Default);
    }
}