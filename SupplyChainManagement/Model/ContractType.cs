using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class ContractType
    {
        public ContractType()
        {
            Requisition = new HashSet<Requisition>();
        }

        public int ContractTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Requisition> Requisition { get; set; }
    }
}
