using Invoice.Domain.Entities.Base;

namespace Invoice.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        
        public ICollection<InvoiceItem> InvoiceItems { get; private set; } = new List<InvoiceItem>();

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
