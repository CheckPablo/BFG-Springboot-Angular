using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
   public static  class DepartmentExtension
    {
        public static void Map(this Department dbDepartment , Department department)
        {
            dbDepartment.DepartmentName = department.DepartmentName;
        }
    }
}
