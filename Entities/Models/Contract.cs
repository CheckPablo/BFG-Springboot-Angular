﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Contract
    {
        public Guid ContractId { get; set; }
        public string Description { get; set; }
        public Guid ContractTypeId { get; set; }
    }
}
