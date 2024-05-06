using Invoice.Domain.Entities.Base;

namespace Invoice.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public Customer()
        {
        }

        public Customer(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
        }
    }
}
