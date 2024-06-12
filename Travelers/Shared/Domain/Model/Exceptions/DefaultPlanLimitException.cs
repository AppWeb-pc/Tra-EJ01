namespace Travelers.Shared.Domain.Model.Exceptions;

public class DefaultPlanLimitException : Exception
{
    public DefaultPlanLimitException() : base("Default plan limit reached.") { }
    
    public DefaultPlanLimitException(Exception innerException) : base("Default plan limit reached.", innerException) { }
}