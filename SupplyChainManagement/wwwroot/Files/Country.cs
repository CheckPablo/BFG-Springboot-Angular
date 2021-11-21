using System;
using System.Collections.Generic;



namespace Entities.Models
{
    public class Country
    {
        public Country()
        {
            Province = new HashSet<Province>();
            Supplier = new HashSet<Supplier>();
        }

        public Guid CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Province> Province { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
