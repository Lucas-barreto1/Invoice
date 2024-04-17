using Invoice.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Collectors.Infra.Data.Mapping.Entities
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Domain.Entities.Invoice>
    {
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

            builder.HasOne(x => x.InvoiceItems)
                .WithMany() // Uma fatura tem um varios items de fatura
                .HasForeignKey(x => x.InvoiceItemId)
                .IsRequired();
        }
    }
}