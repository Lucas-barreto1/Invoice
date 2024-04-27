namespace Invoice.Core.Dtos;

public class InvoiceResponseDto
{
    public Guid Id { get; set; }
    public DateTime IssueDate { get; set; }
    public double TotalAmount { get; set; }
       
    public Guid? CustomerId { get; set; }
    
    public List<InvoiceItemResponseDto> InvoiceItems { get; set; }
}