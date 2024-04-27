namespace Invoice.Core.Dtos;

public class InvoiceItemDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}