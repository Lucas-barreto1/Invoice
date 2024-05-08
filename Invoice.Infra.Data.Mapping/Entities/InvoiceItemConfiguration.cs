using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infra.Data.Mapping.Entities
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable(nameof(InvoiceItem));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired(); 

            builder.HasOne(x => x.Product)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();
            
            builder.HasOne(x => x.Invoice)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(x => x.InvoiceId)
                .IsRequired();
        }
    }
}