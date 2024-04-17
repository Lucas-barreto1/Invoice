using System.Runtime.InteropServices.JavaScript;
using Invoice.Collectors.Domain;
using Invoice.Collectors.Domain.Entities;
using Invoice.Collectors.Infra.Data.Mapping;
using Invoice.Collectors.Infra.Data.Mapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Collectors.Context;

public class InvoiceCollectorsContext : DbContext
{
    #region DataSets

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Domain.Entities.Invoice> Invoices { get; set; }

    #endregion
    
    public InvoiceCollectorsContext(DbContextOptions<InvoiceCollectorsContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //   Dá pra fazer aqui (OnConfiguring)...
        //   tudo que foi feito aqui "Invoice.Collectors.Infra.Data.Context.InvoiceCollectorsContextConfiguration"
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* Configurações manuais. Devem ser aplicados os mappings um a um */
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceItemConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
    }
}