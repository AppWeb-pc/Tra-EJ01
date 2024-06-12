namespace Travelers.Shared.Domain.Model.Exceptions;

public class NoValidPlanArgumentException : Exception
{
    public NoValidPlanArgumentException() : base("No valid plan argument.") { }
    
    public NoValidPlanArgumentException(Exception innerException) : base("No valid plan argument.", innerException) { }
}