using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class DocumentSubmissionStatus
    {
        public int DocumentStatusId { get; set; }
        public int ProcessTypeId { get; set; }
        public int? TenderId { get; set; }
        public int? RequisitionId { get; set; }
        public int? SupplierId { get; set; }
        public string Status { get; set; }

        public virtual ProcessType ProcessType { get; set; }
        public virtual Requisition Requisition { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Tender Tender { get; set; }
    }
}
