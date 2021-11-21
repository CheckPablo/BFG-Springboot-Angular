using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyChainManagement.Model
{
    public partial class Requisition
    {
        public Requisition()
        {
            Attachment = new HashSet<Attachment>();
            DocumentSubmissionStatus = new HashSet<DocumentSubmissionStatus>();
            Notification = new HashSet<Notification>();
        }

        public int RequisitionId { get; set; }
        public Guid RequisitionNo { get; set; }
        public string RequisitionTitle { get; set; }
        public int? RequisitionTypeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? ShippingMethodId { get; set; }
        public string Motivation { get; set; }
        public string QueriesName { get; set; }
        public string QueriesPhone { get; set; }
        public string QueriesEmail { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public bool? SiteVisitRequired { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentDescription { get; set; }
        public bool? OverwriteExistingAttachment { get; set; }
        public bool? AttachmentVisibleToSupplier { get; set; }
        public bool? ApprovalException { get; set; }
        public bool? IsComplete { get; set; }
        public int? ClassificationId { get; set; }
        public bool? ServiceItem { get; set; }
        public int? CommodityId { get; set; }
        public string Item { get; set; }
        public int? UnitOfMeasure { get; set; }
        public string Glaccount { get; set; }
        public string ItemDescription { get; set; }
        public string DetailedDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Vattotal { get; set; }
        public decimal? Total { get; set; }
        public string RequestedBy { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? CityId { get; set; }
        public string DeliveryAddress { get; set; }
        public int? DemandPlanId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        public virtual City City { get; set; }
        public virtual Classification Classification { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual DemandPlan DemandPlan { get; set; }
        public virtual Department Department { get; set; }
        public virtual RequisitionType RequisitionType { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<DocumentSubmissionStatus> DocumentSubmissionStatus { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
    }
}
