using Invoice.Domain.Entities.Base;

namespace Invoice.Domain.Entities
{
    public class Invoice : EntityBase
    {
       public DateTime IssueDate { get; set; }
       public double TotalAmount { get; set; }
       
       public Guid? CustomerId { get; set; }
       public Customer? Customer { get; set; }
       
       public ICollection<InvoiceItem>? InvoiceItems { get; private set; }
       
       
        public Invoice() { }

        public Invoice(DateTime issueDate)
        {
            IssueDate = issueDate;
        }
        
        public void addInvoiceItem(Product product, int quantity)
        {
            if (InvoiceItems == null)
            {
                InvoiceItems = new List<InvoiceItem>();
            }
            
            InvoiceItems.Add(new InvoiceItem(quantity, product));
        }
        
        public void removeInvoiceItem(InvoiceItem invoiceItem)
        {
            if (InvoiceItems == null)
            {
                return;
            }
            InvoiceItems.Remove(invoiceItem);
        }
        
        private void updateTotalAmount()
        {
            if (InvoiceItems == null)
            {
                return;
            }
            TotalAmount = InvoiceItems.Sum(i => i.Quantity * i.Product.Price);
        }
    }
}