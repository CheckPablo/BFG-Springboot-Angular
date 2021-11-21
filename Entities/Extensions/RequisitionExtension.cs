using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class RequisitionExtension
    {
        public static void Map(this Requisition dbRequisition, Requisition requisition)
        {
           
            dbRequisition.RequisitionTitle = requisition.RequisitionTitle;
            dbRequisition.DepartmentId = requisition.DepartmentId;
            dbRequisition.ShippingMethodId = requisition.ShippingMethodId;
            dbRequisition.ContractTypeId = requisition.ContractTypeId;
            dbRequisition.RequisitionTypeId = requisition.RequisitionTypeId;
            dbRequisition.QueriesEmail = requisition.QueriesEmail;
            dbRequisition.QueriesName = requisition.QueriesName;
            dbRequisition.QueriesPhone = requisition.QueriesPhone;
            dbRequisition.Motivation = requisition.Motivation;
            dbRequisition.CreatedBy = requisition.CreatedBy;
            dbRequisition.Status = requisition.Status;

        }
    }
}
