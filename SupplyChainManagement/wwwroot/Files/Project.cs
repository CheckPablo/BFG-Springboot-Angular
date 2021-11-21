using System;
using System.Collections.Generic;



namespace Entities.Models
{
    public class Project
    {
        public Project()
        {
            Tender = new HashSet<Tender>();
        }

        public Guid ProjectId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tender> Tender { get; set; }
    }
}
