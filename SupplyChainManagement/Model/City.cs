using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class City
    {
        public City()
        {
            Municipality = new HashSet<Municipality>();
            Requisition = new HashSet<Requisition>();
            Supplier = new HashSet<Supplier>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Municipality> Municipality { get; set; }
        public virtual ICollection<Requisition> Requisition { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
