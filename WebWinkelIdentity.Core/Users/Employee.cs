using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WebWinkelIdentity.Core.StoreEntities;

namespace WebWinkelIdentity.Core
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string IBAN { get; set; }
        public bool CurrentlyEmployed { get; set; }
        public List<StoreEmployee> EmployeeStores { get; set; }
    }
}
