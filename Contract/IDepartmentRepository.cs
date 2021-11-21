using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
   public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentByDepartmentId(string departmentId);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department dbDepartment, Department department);
    }
}
