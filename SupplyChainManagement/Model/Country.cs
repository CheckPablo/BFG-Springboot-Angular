﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class Country
    {
        public Country()
        {
            Province = new HashSet<Province>();
            Supplier = new HashSet<Supplier>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Province> Province { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}