namespace Invoice.Core.Dtos;

public class InvoiceItemResponseDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public ProductResponseDto? Product { get; set; }
}