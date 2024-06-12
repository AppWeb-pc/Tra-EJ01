using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Interface.REST.Resources;

namespace Travelers.Subscriptions.Interface.REST.Transform;

public class CreatePlanCommandFromResourceAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource)
    {
        return new CreatePlanCommand(resource.Name, resource.MaxUsers, resource.Default);
    }
}