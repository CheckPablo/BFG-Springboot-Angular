using System;
using System.Collections.Generic;



namespace Entities.Models
{
    public class FinancialYear
    {
        public FinancialYear()
        {
            Tender = new HashSet<Tender>();
        }

        public Guid FinancialYearId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tender> Tender { get; set; }
    }
}
