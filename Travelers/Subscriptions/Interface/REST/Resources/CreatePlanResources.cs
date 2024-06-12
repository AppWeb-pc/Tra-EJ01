namespace Travelers.Subscriptions.Interface.REST.Resources;

public record CreatePlanResource(
    string Name, 
    int MaxUsers, 
    int Default
    );