using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Tender
    {
        public Tender()
        {
            Attachment = new HashSet<Attachment>();
            DocumentSubmissionStatus = new HashSet<DocumentSubmissionStatus>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TenderId { get; set; }
        public string Description { get; set; }
        public int TenderTypeId { get; set; }
        public int TenderOutcomeId { get; set; }
        public int FinancialYearId { get; set; }
        public int DepartmentId { get; set; }
        public int ProjectId { get; set; }
        public int ClassificationId { get; set; }
        public double? EstimatedValue { get; set; }
        public string Buyer { get; set; }
        public string CommitteeCoordinator { get; set; }
        public string TenderCoordinator { get; set; }
        public DateTime TenderAdvertDate { get; set; }
        public int NumberOfSuppliers { get; set; }

        public virtual Classification Classification { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual Project Project { get; set; }
        public virtual TenderType TenderType { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
    }
}
