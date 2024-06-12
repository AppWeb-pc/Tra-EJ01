using Microsoft.EntityFrameworkCore;
using Travelers.Shared.Infrastructure.Persistence.EFC.Configuration.Extension;
using Travelers.Subscriptions.Domain.Model.Aggregate;

namespace Travelers.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    DbSet<Plan> Plans { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("No database provider has been configured for this context.");
        }
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Plan>().ToTable("plans");
        modelBuilder.Entity<Plan>().HasKey(p => p.Id);
        modelBuilder.Entity<Plan>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Plan>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Plan>().Property(p => p.Default).IsRequired();
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}