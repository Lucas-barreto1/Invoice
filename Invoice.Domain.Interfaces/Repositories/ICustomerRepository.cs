using Invoice.Core.Dtos;
using Invoice.Domain.Interfaces.Repositories.Base;
using Invoice.Domain.Entities;

namespace Invoice.Domain.Interfaces.Repositories;

public interface ICustomerRepository: IRepositoryBase<Customer>
{
    Task<IEnumerable<ProductsByCustomerResponseDto>> GetProductsByCustomerId(Guid customerId, CancellationToken cancellationToken = default);
}