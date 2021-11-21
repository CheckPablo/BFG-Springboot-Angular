using Contract;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IRequisitionRepository _requisitionRepository;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IRequisitionRepository Requisition
        {
            get
            {

                if (_requisitionRepository== null)
                {
                    _requisitionRepository = new RequisitionRepository(_repositoryContext);
                }
                return _requisitionRepository;
            }
        }
    }
}
