namespace Travelers.Subscriptions.Domain.Model.Commands;

public record CreatePlanCommand(
    string Name, 
    int MaxUsers, 
    int Default
    );