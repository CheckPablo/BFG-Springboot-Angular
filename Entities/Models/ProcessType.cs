using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class ProcessType
    {
        public ProcessType()
        {
            Attachment = new HashSet<Attachment>();
            DocumentSubmissionStatus = new HashSet<DocumentSubmissionStatus>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessTypeId { get; set; }
        public string ProcessName { get; set; }

        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
    }
}
