using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public int? ProcessTypeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public int? ProcessId { get; set; }

        public virtual Requisition Process { get; set; }
        public virtual Tender Process1 { get; set; }
        public virtual Supplier ProcessNavigation { get; set; }
    }
}
