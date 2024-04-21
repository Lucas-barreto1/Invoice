using Invoice.Domain.Entities;
using Invoice.Infra.Data.Mapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Context;

public class InvoiceContext : DbContext
{
    #region DataSets

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Domain.Entities.Invoice> Invoices { get; set; }

    #endregion
    
    public InvoiceContext(DbContextOptions<InvoiceContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //   Dá pra fazer aqui (OnConfiguring)...
        //   tudo que foi feito aqui "Invoice.Infra.Data.Context.InvoiceContextConfiguration"
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