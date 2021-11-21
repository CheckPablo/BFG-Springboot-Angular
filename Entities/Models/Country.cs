using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            Province = new HashSet<Province>();
            Supplier = new HashSet<Supplier>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Province> Province { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
