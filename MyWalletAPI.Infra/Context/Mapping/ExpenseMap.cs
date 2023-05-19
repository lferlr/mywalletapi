using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWalletAPI.Domain.Entities;

namespace MyWalletAPI.Infra.Context.Mapping;

public class ExpenseMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expense");
        builder.Property(x => x.Id);
        // Identity
        builder.Property(x => x.Category)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");
        builder.Property(x => x.Description)
            .HasMaxLength(250)
            .HasColumnType("varchar(250)");
        builder.Property(x => x.Tag);
        builder.Property(x => x.Value);
        builder.Property(x => x.DueDate);
        builder.Property(x => x.RegistrationDate);
        builder.Property(x => x.Status);
        builder.Property(x => x.UserId);
        builder.Property(x => x.MethodPayment);
    }
}