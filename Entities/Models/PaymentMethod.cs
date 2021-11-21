﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Supplier = new HashSet<Supplier>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentMethodId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
