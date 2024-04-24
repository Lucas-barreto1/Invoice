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

            builder.HasOne(x => x.Customer)
                .WithMany() // Um cliente tem varias faturas
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();
            
        }
    }
}