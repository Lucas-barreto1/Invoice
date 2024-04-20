﻿using Invoice.Collectors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoice.Collectors.Infra.Data.Mapping.Entities;


public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsUnicode()
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .IsRequired();
    }
}