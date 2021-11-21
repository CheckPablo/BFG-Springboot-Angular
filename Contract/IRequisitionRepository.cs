using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
   public interface IRequisitionRepository: IRepositoryBase<Requisition>
    {
        Task <IEnumerable<Requisition>> GetAllNewRequisitions();
        Task<IEnumerable<Requisition>> GetAllInprogressRequisitions();
        Task<IEnumerable<Requisition>> GetAllApprovedRequisitions();
        Task<IEnumerable<Requisition>> GetAllDeclinedRequisitions();
        Requisition GetRequisitionByRequisitionNo(Guid requisitionNo);
        void CreateRequisition(Requisition requisition);
        void UpdateRequsition(Requisition dbRequisition, Requisition requisition);
    }
}
