using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infra.Data.Mapping.Entities
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Domain.Entities.Invoice>
    {
        private IEntityTypeConfiguration<Domain.Entities.Invoice> _entityTypeConfigurationImplementation;

        public void Configure(EntityTypeBuilder<Domain.Entities.Invoice> builder)
        {
            builder.ToTable(nameof(Invoice));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IssueDate)
                .IsRequired();

            builder.Property(x => x.TotalAmount)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();
            
            builder.HasMany(x => x.InvoiceItems)
                .WithOne(c => c.Invoice)
                .HasForeignKey(x => x.InvoiceId)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(c => c.Invoices) // Um cliente tem varias faturas
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();
            
        }
    }
}