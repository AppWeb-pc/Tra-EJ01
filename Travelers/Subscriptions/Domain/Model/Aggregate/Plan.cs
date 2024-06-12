using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Travelers.Subscriptions.Domain.Model.Commands;

namespace Travelers.Subscriptions.Domain.Model.Aggregate;

public partial class Plan
{
    public long Id { get;  set; }
    [Required]
    public string Name { get;  set; }
    [Required]
    public int MaxUsers { get;  set; }
    [Required]
    public int Default { get;  set; }
}

public partial class Plan
{
    public Plan()
    {
        Name = String.Empty;
        MaxUsers = 0;
        Default = 0;
    }
    
    public Plan(string name, int maxUsers, int @default)
    {
        Name = name;
        MaxUsers = maxUsers;
        Default = @default;
    }
    
    public Plan(CreatePlanCommand commad)
    {
        Name = commad.Name;
        MaxUsers = commad.MaxUsers;
        Default = commad.Default;
    }
}