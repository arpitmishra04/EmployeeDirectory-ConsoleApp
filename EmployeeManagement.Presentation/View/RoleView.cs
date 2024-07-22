using ConsoleTables;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.View
{
    public class RoleView
    {
        static  RoleService roleService = new RoleService();
        static LocationService locationService = new LocationService(); 
        public static void ViewAll()
        {

            List<RoleModel> roleList = roleService.ViewAll();
            List <LocationModel>locationList= locationService.ViewAll();
            
            var table = new ConsoleTable(
                "Role Name",
                "Department",
                "Description",
                 "Location"
                   );

            foreach (RoleModel role in roleList)
            {
                table.AddRow(
                    
                    role.RoleName,
                    role.Department,
                    role.Description,
                    locationList.Find(location=>location.LocationId== role.LocationId)!.LocationName
                    
                    );



            }
            Console.WriteLine(table.ToString());


        }
        
    }
}
