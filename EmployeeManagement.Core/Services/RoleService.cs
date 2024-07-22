using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Model;

namespace EmployeeManagement.Core.Services
{
    public class RoleService : IRoleService
    {
        List<RoleModel> roleList = RoleDataAccess.GetAll();
        public bool Add(RoleModel role)
        {
            if (roleList == null)
            {
                roleList = new List<RoleModel>();
            }
            roleList.Add(role);
            return RoleDataAccess.Set(roleList); ;
        }

        public List<RoleModel> ViewAll()
        {
            return RoleDataAccess.GetAll();
        }
    }
}
