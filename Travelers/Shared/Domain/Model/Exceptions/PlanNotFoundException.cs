namespace Travelers.Shared.Domain.Model.Exceptions;

public class PlanNotFoundException : Exception
{
    public PlanNotFoundException(long id) : base($"Plan with ID {id} not found.") { }
}