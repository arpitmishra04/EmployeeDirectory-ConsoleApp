using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Operations
{
    public class RoleOperation
    {
        static RoleService roleService = new RoleService();
        static List<RoleModel> rolelist = roleService.ViewAll();
        

        public static string Add()
        {

            Console.WriteLine("Enter Role");
            string jobTitle = Input.GetNameTypeInput("Role");
            if (jobTitle == "0") return "";

            Console.WriteLine("Enter Department for the Role");
            string department = Input.GetNameTypeInput("Department");
            if (department == "0") return "";

            Console.WriteLine("Enter the description for the role");
            string description = Console.ReadLine()!;
            if (description == "0") return "";

            Console.WriteLine("Enter Location of the Employee");
            int locationId = Input.GetLocation();
            if (locationId == 0) return "";


            RoleModel role = new RoleModel
            {
                RoleName = jobTitle,
                Department = department,
                Description = description,
                LocationId = locationId,

            };

            bool isSuccess = roleService.Add(role);
            if (isSuccess)
            {
                Console.WriteLine("Role Added Successfully");
            }

            return jobTitle;


        }
    }
}