namespace Travelers.Subscriptions.Domain.Model.Commands;

public class DeletePlanCommand(long id)
{
    public long Id { get; }
}