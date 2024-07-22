using EmployeeManagement.Presentation.Operations;
using EmployeeManagement.Presentation.View;

namespace EmployeeManagement.Presentation.Presentation
{
    internal class EmployeePresentation
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Go Back \n1. Add Employee \n2. View All Employee \n3. View specific Employee \n4. Edit Employee \n5. Delete Employee");
                
                Console.Write("Choose an option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "0": return;

                    case "1":
                        EmployeeOperation.Add();

                        break;
                    case "2":
                        EmployeeView.ViewAll();

                        break;
                    case "3":
                        EmployeeView.ViewOne();

                        break;
                    case "4":EmployeeOperation.Update();

                        break;
                    case "5":EmployeeOperation.Delete();

                        break;
            
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
