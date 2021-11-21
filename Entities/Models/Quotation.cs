using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Quotation
    {
        public Quotation()
        {
            Attachment = new HashSet<Attachment>();
        }
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotationId { get; set; }
        public int? SupplierId { get; set; }
        public int? RequisitionId { get; set; }
        public string Item { get; set; }
        public string ItemDescription { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double? Total { get; set; }
        public string BillToAddress { get; set; }
        public string BillToName { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string TermsAndContions { get; set; }
        public string SpecialNotesAndInstructions { get; set; }
        public double? SubTotal { get; set; }
        public double? TaxRate { get; set; }
        public DateTime? ValidUntil { get; set; }
        public double? TotalTaxedAmount { get; set; }
        public string QuoteCreatedBy { get; set; }
        public string QuotationName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierFax { get; set; }
        public string SupplierEmail { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
