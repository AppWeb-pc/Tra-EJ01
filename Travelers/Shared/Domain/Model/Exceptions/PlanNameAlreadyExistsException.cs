namespace Travelers.Shared.Domain.Model.Exceptions;

public class PlanNameAlreadyExistsException : Exception
{
    public PlanNameAlreadyExistsException(string name) : base($"Plan with name {name} already exists.") { }
    
    public PlanNameAlreadyExistsException(string name, Exception innerException) : base($"Plan with name {name} already exists.", innerException) { }
}