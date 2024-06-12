namespace Travelers.Subscriptions.Interface.REST.Resources;

public record PlanResource(long Id, string Name, int MaxUsers, int Default);