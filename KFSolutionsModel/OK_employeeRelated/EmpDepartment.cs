using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class EmpDepartment : TypeTable
    {
        public Int64 DefaultPermissions { get; set; } = 0;

        //--------------navigation propertys-----------//
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
