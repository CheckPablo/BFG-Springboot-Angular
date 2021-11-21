using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyChainManagement.Models
{
    public class UserInformation : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }

    }
}
