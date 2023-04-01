using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MyWalletAPI.Domain.Entities;
using MyWalletAPI.Infra.Context.Mapping;

namespace MyWalletAPI.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ExpenseMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.Ignore<Notification>();
    }
}