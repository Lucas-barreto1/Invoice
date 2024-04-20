using Invoice.Collectors.Domain.Entities.Base;

namespace Invoice.Collectors.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

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
