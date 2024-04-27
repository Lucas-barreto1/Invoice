using Invoice.Domain.Entities;

namespace Invoice.Core.Dtos;

public class InvoiceItemResponseDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }
}