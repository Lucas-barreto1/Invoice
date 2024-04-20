using Invoice.Collectors.Domain.Entities.Base;

namespace Invoice.Collectors.Domain.Entities
{
    public class Invoice : EntityBase
    {
       public DateTime IssueDate { get; set; }
       public double TotalAmount { get; set; }
       
       public Guid? CustomerId { get; set; }
       public Customer? Customer { get; set; }
       
       public ICollection<InvoiceItem>? InvoiceItems { get; }
       
       
        public Invoice() { }

        public Invoice(DateTime issueDate, double totalAmount)
        {
            IssueDate = issueDate;
            TotalAmount = totalAmount;
        }

    }
}