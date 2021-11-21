using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Attachment = new HashSet<Attachment>();
            DocumentSubmissionStatus = new HashSet<DocumentSubmissionStatus>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int ClassificationId { get; set; }
        public string LegalName { get; set; }
        public string RegistrationNo { get; set; }
        public bool Vatregistered { get; set; }
        public string VatregistrationNo { get; set; }
        public int Bbbeeid { get; set; }
        public string Currency { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentTermId { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Surburb { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public int MunicipalityId { get; set; }
        public int WardId { get; set; }
        public int PostalCode { get; set; }
        public int CountryId { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonSurname { get; set; }
        public string ContactPersonPosition { get; set; }
        public string ContactPersonTelephone { get; set; }
        public string ContactPersonFax { get; set; }
        public string ContactPersonCell { get; set; }
        public string ContactPersonEmail { get; set; }
        public bool QuotationContact { get; set; }

        public virtual City City { get; set; }
        public virtual Classification Classification { get; set; }
        public virtual Country Country { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Province Province { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
    }
}
