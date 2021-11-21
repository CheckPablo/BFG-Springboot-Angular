﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Department
    {
        public Department()
        {
            Requisition = new HashSet<Requisition>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Requisition> Requisition { get; set; }
    }
}
