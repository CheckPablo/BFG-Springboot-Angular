using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class ProcessType
    {
        public ProcessType()
        {
            DocumentSubmissionStatus = new HashSet<DocumentSubmissionStatus>();
        }

        public int ProcessTypeId { get; set; }
        public string ProcessName { get; set; }

        public virtual ICollection<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
    }
}
