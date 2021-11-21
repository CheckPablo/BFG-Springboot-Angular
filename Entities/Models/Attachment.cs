using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentId { get; set; }
        public int? ProcessTypeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public int? ProcessId { get; set; }

        public virtual Quotation Process { get; set; }
        public virtual Supplier Process1 { get; set; }
        public virtual Tender Process2 { get; set; }
        public virtual Requisition ProcessNavigation { get; set; }
        public virtual ProcessType ProcessType { get; set; }
    }
}
