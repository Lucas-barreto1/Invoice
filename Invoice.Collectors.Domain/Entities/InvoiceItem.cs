using Invoice.Collectors.Domain.Entities.Base;

namespace Invoice.Collectors.Domain.Entities
{
    public class InvoiceItem : EntityBase
    {
        public int Quantity { get; set; }
        
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
        
        public Guid? InvoiceId { get; set; }
        
        public Invoice Invoice { get; set; }

        public InvoiceItem() { }

        public InvoiceItem(int quantity)
        {
            Quantity = quantity;
        }
    }
}