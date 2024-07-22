using EmployeeManagement.Presentation.Presentation;

namespace EmployeeManagement.Presentation
{
    public class ApplicationPresenter
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("0. Exit \n1. Employee Management \n2. Role Management ");
                
                Console.Write("\nChoose an option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        EmployeePresentation.Start();
                        break;
                    case "2":
                        RolePresentation.Start();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
