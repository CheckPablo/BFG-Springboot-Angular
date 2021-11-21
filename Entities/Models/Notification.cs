using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }
        public int RequisitionId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }
        public string Link { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string Cc { get; set; }

        public virtual Requisition Requisition { get; set; }
    }
}
