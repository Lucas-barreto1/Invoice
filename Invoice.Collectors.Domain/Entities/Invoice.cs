using Invoice.Collectors.Domain.Entities.Base;

namespace Invoice.Collectors.Domain.Entities
{
    public class Invoice : EntityBase
    {
       public DateTime IssueDate { get; set; }
       public double TotalAmount { get; set; }
       public Guid? CustomerId { get; set; }
       public virtual Customer? Customer { get; set; }
       
       public Guid? InvoiceItemId { get; set; }
       public virtual ICollection<InvoiceItem>? InvoiceItems { get; set; }
       
       
        public Invoice() { }

        public Invoice(DateTime issueDate, double totalAmount)
        {
            IssueDate = issueDate;
            TotalAmount = totalAmount;
        }

    }
}