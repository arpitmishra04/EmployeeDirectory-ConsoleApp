using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Interfaces
{
    internal interface IRoleService
    {
        bool Add( RoleModel role);
        List<RoleModel> ViewAll();
    }
}
