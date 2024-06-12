using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Interface.REST.Resources;

namespace Travelers.Subscriptions.Interface.REST.Transform;

public class UpdatePlanCommandFromResourceAssembler
{
    public static UpdatePlanCommand ToCommandFromResource(UpdatePlanResource resource)
    {
        return new UpdatePlanCommand(resource.Id, resource.Name, resource.MaxUsers, resource.Default);
    }
}