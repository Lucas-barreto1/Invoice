namespace Invoice.Core.Dtos;

public class InvoiceDto
{
    public Guid Id { get; set; }
    public DateTime IssueDate { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public List<InvoiceItemDto> InvoiceItems { get; set; }
}