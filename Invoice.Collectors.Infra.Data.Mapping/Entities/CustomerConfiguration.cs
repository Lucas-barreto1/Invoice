using Invoice.Collectors.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Collectors.Infra.Data.Mapping;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsUnicode(false)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(200);
    }
}