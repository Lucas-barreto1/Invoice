using Invoice.Domain.Entities.Base;

namespace Invoice.Domain.Entities
{
    public class Invoice : EntityBase
    {
       public DateTime IssueDate { get; set; }
       public double TotalAmount { get; set; }
       
       public Guid? CustomerId { get; set; }
       public Customer? Customer { get; set; }
       
       public ICollection<InvoiceItem> InvoiceItems { get; private set; } = new List<InvoiceItem>();
       
       
        public Invoice() { }

        public Invoice(DateTime issueDate)
        {
            IssueDate = issueDate;
        }
        
        public void addInvoiceItem(Product product, int quantity)
        {
            InvoiceItems.Add(new InvoiceItem(quantity, product, this));
            updateTotalAmount();
        }
        
        public void removeInvoiceItem(InvoiceItem invoiceItem)
        {
            InvoiceItems.Remove(invoiceItem);
            updateTotalAmount();
        }
        
        private void updateTotalAmount()
        {
            TotalAmount = InvoiceItems.Sum(i => i.Quantity * i.Product.Price);
        }
    }
}