using System.Collections.Generic;

namespace WebWinkelIdentity.Core
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public string Description { get; set; }
        public List<Brand> Brands { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
