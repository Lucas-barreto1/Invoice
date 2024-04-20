using Invoice.Collectors.Domain.Entities.Base;

namespace Invoice.Collectors.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }

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
