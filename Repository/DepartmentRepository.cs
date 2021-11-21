using Contract;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private RepositoryContext _repositoryContext;
        public DepartmentRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            var departments = _repositoryContext.Department.ToList();
            return departments;
        }

        public Department GetDepartmentByDepartmentId(string departmentId)
        {
            var department = _repositoryContext.Department.Where(d => d.DepartmentId.Equals(departmentId)).SingleOrDefault();
            return department;
        }

        public void CreateDepartment(Department department)
        {
            Create(department);
            Save();

        }

        public void UpdateDepartment(Department dbDepartment, Department department)
        {
            dbDepartment.Map(department);
            Update(dbDepartment);
            Save();
        }
    }
}
