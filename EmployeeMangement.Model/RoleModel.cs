using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class RoleModel
    {
        public required string RoleName { get; set; }
        public required string Department { get; set; }
        public required string Description { get; set; }
        public required int LocationId { get; set; }
       
    }
}
