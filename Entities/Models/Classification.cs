using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Classification
    {
        public Classification()
        {
            Requisition = new HashSet<Requisition>();
            Supplier = new HashSet<Supplier>();
            Tender = new HashSet<Tender>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassificationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Requisition> Requisition { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
    }
}
