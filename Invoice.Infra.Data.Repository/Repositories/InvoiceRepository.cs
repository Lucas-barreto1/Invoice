using Invoice.Context;
using Invoice.Infra.Data.Repository.Repositories.Base;
using Invoice.Domain.Interfaces;

namespace Invoice.Infra.Data.Repository.Repositories;

public class InvoiceRepository: RepositoryBase<Domain.Entities.Invoice>, IInvoiceRepository
{
    public InvoiceRepository(InvoiceContext context) : base(context)
    {
    }
}