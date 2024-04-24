using Invoice.Context;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infra.Data.Repository.Repositories.Base;

namespace Invoice.Infra.Data.Repository.Repositories;

public class ProductRepository: RepositoryBase<Product>, IProductRepository
{   
    public ProductRepository(InvoiceContext context) : base(context)
    {
    }
}
