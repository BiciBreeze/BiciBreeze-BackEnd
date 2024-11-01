using Security.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Security.IAM.Domain.Model.Aggregates;
using Security.Rent.Domain.Model.Aggregates;

namespace Security.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        
        
        // IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        //Rent Context
        builder.Entity<ConcreteOrder>().HasKey(o => o.Id);
        builder.Entity<ConcreteOrder>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ConcreteOrder>().Property(o => o.OrderNumber).IsRequired();
        builder.Entity<ConcreteOrder>().Property(o => o.CustomerId).IsRequired();

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}