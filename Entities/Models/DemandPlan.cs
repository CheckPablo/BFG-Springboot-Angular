using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class DemandPlan
    {
        public DemandPlan()
        {
            Requisition = new HashSet<Requisition>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DemandPlanId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<Requisition> Requisition { get; set; }
    }
}
