namespace Invoice.Core.Dtos;

public class InvoiceResponseDto
{
    public DateTime IssueDate { get; set; }
    public double TotalAmount { get; set; }
       
    public Guid? CustomerId { get; set; }
    
    public List<Guid> InvoiceItemsIds { get; set; }
}