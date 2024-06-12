namespace Travelers.Subscriptions.Interface.REST.Resources;

public record UpdatePlanResource(
    long Id,
    string Name,
    int MaxUsers,
    int Default
);