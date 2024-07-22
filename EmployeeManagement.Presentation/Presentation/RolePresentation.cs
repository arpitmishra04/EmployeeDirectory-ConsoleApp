using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Presentation
{
    internal class RolePresentation
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Go Back \n1. Add Role \n2. View All Roles \nChoose an option: ");
                
                string option = Console.ReadLine()!;
                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        RoleOperation.Add();
                        break;
                    case "2":
                        RoleView.ViewAll();
                        break;
                    
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
