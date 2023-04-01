using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWalletAPI.Domain.Entities;

namespace MyWalletAPI.Infra.Context.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.Property(x => x.Id);
        builder.Property(x => x.FirstName)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");
        
        builder.Property(x => x.LastName)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)");

        builder.Property(x => x.Email);
        builder.Property(x => x.Salary)
            .HasColumnType("INT");
    }
}