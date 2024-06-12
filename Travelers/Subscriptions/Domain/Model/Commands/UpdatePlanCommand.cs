namespace Travelers.Subscriptions.Domain.Model.Commands;

public record UpdatePlanCommand(
    long Id,
    string Name, 
    int MaxUsers, 
    int Default
);