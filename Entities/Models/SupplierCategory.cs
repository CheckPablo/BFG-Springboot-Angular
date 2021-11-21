using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class SupplierCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierCategoryId { get; set; }
        public string SupplierCategory1 { get; set; }
        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
