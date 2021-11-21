using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class Ward
    {
        public Ward()
        {
            Supplier = new HashSet<Supplier>();
        }

        public int WardId { get; set; }
        public string WardName { get; set; }
        public int MunicipalityId { get; set; }

        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
