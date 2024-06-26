﻿using Invoice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Infra.Data.Mapping.Entities;

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
        
        builder.HasMany(x => x.Invoices)
            .WithOne(c => c.Customer) 
            .HasForeignKey(x => x.CustomerId)
            .IsRequired();
    }
}