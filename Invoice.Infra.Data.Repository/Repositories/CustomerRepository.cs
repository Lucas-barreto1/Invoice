using Invoice.Context;
using Invoice.Core.Dtos;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infra.Data.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infra.Data.Repository.Repositories;

public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(InvoiceContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<ProductsByCustomerResponseDto>> GetProductsByCustomerId(Guid customerId, CancellationToken cancellationToken = default)
    {
       return await _context.Customers
            .Where(x => x.Id == customerId)
            .Include(x => x.Invoices)
            .ThenInclude(x => x.InvoiceItems)
            .ThenInclude(x => x.Product)
            .Select(x => new ProductsByCustomerResponseDto
            {
                CustomerName = x.Name,
                ProductsNames = x.Invoices.SelectMany(x => x.InvoiceItems).Select(x => x.Product.Name).ToList()
            })
            .ToListAsync(cancellationToken);
    }
}