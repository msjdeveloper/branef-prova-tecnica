using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanySystem.Infrastructure.Persistence.Configurations;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        ConfigureCompanyTable(builder);
    }

    private void ConfigureCompanyTable(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CompanyId.Create(value));

        builder.Property(c => c.Cnpj)
            .HasColumnType("varchar(14)")
            .IsRequired();

        builder.Property(c => c.CompanyName)
            .HasColumnType("varchar(200)");

        builder.Property(c => c.BusinessName)
            .HasColumnType("varchar(200)");

        builder.Property(c => c.Size)
            .ValueGeneratedNever()
            .HasConversion(
                status => status!.Value,
                value => CompanySize.FromValue(value));
    }
}
