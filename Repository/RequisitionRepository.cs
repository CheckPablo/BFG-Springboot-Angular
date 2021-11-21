using Contract;
using Entities;
using Entities.Extensions;
using Entities.Models;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace Repository
{
    public class RequisitionRepository : RepositoryBase<Requisition>, IRequisitionRepository
    {
        private RepositoryContext _repositoryContext;
       
        public RequisitionRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
           
         
        }
        public async Task<IEnumerable<Requisition>> GetAllNewRequisitions()
        {
            var requisitions = RepositoryContext.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Where(r => r.IsComplete.Equals(true)&& r.Status.Equals("New")).OrderByDescending(r => r.RequisitionId).ToListAsync();
            
            return (await requisitions);
        }

        public async Task<IEnumerable<Requisition>> GetAllInprogressRequisitions()
        {
            var requisitions = RepositoryContext.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Where(r => r.IsComplete.Equals(true) && r.Status.Equals("Inprogress")).ToListAsync();

            return (await requisitions);
        }

        public async Task<IEnumerable<Requisition>> GetAllApprovedRequisitions()
        {
            var requisitions = RepositoryContext.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Where(r => r.IsComplete.Equals(true) && r.Status.Equals("Approved")).ToListAsync();

            return (await requisitions);
        }

        public async Task<IEnumerable<Requisition>> GetAllDeclinedRequisitions()
        {
            var requisitions = RepositoryContext.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Where(r => r.IsComplete.Equals(true) && r.Status.Equals("Declined")).ToListAsync();

            return (await requisitions);
        }



        public Requisition GetRequisitionByRequisitionNo(Guid requisitionNo)
        {
            var requisition = RepositoryContext.Requisition.Where(r => r.RequisitionNo.Equals(requisitionNo)).SingleOrDefault();
            return requisition;
        }

        public void CreateRequisition(Requisition requisition)
        {
            Create(requisition);
            Save();
        }

        public void UpdateRequsition(Requisition dbRequisition, Requisition requisition)
        {
            dbRequisition.Map(requisition);
            Update(dbRequisition);
            Save();

        }

        
    }
}
