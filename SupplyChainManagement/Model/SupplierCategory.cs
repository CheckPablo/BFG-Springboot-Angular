using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class SupplierCategory
    {
        public int SupplierCategoryId { get; set; }
        public string SupplierCategory1 { get; set; }
        public int? SupplierId { get; set; }
        public string ProductsAndServices { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
