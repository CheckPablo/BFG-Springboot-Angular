using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Municipality
    {
        public Municipality()
        {
            Supplier = new HashSet<Supplier>();
            Ward = new HashSet<Ward>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MunicipalityId { get; set; }
        public string MunicipalityName { get; set; }
        public string MunicipalityAddress { get; set; }
        public string MunicipalityTelephone { get; set; }
        public string MunicipalityEmailAddress { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
        public virtual ICollection<Ward> Ward { get; set; }
    }
}
