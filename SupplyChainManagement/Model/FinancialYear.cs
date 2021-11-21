using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class FinancialYear
    {
        public FinancialYear()
        {
            Tender = new HashSet<Tender>();
        }

        public int FinancialYearId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tender> Tender { get; set; }
    }
}
