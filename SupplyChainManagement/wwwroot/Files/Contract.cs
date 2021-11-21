using System;
using System.Collections.Generic;



namespace Entities.Models
{
    public class Contract
    {
        public Guid ContractId { get; set; }
        public string Description { get; set; }
        public Guid ContractTypeId { get; set; }

        public virtual ContractType ContractType { get; set; }
    }
}
