using EmployeeManagement.Model;
using System.Xml.Schema;
using System.Text.RegularExpressions;
using EmployeeManagement.Presentation.Inputs;
using EmployeeManagement.Presentation.View;
using EmployeeManagement.Presentation.Validations;
using EmployeeManagement.Core.Services;
using System.Reflection;
namespace EmployeeManagement.Presentation.Operations
{
   
    internal class EmployeeOperation
    {
        private static string emp="", jobTitle="", firstName = "", lastName = "", dob = "", email = "", mobile = "", joiningDate = "",department = "" ,manager = "",project = ""; 
        private static int locationID=0;
        private static bool isExit = false;
        private static Dictionary<string, Action> methodList = new Dictionary<string, Action>();
        
         

        static EmployeeOperation()
        {
            MethodList();
        }
        private static void EmployeeNumber()
        {
            Console.WriteLine("\n Enter Employee Number (eg:TZXXXX)");
            emp = Input.GetId(0);
            if (emp == "0") isExit=true;
        }
        private static void FirstName()
        {
            Console.WriteLine("\n Enter First Name:");
            firstName = Input.GetNameTypeInput("FirstName");
            if (firstName == "0") isExit=true;
        }

        private static void LastName() {
            Console.WriteLine("\n Enter Last Name:");
             lastName = Input.GetNameTypeInput("LastName");
            if (lastName == "0") isExit=true;
        }

        private static void DOB()
        {
            Console.WriteLine("\n Enter Date of Birth (DD/MM/YYYY)");
            dob = Input.GetDateOfBirth();
            if (dob == "0") isExit = true;
        }

        private static void Email()
        {
            Console.WriteLine("\n Enter Email:");
             email = Input.GetEmail();
            if (email == "0") isExit = true;
        }


        private static void Phone()
        {
            Console.WriteLine("\n Enter Mobile Number:");
             mobile = Input.GetMobileNumber();
            if (mobile == "0") isExit = true;
        }

        private static void JoiningDate()
        {
            Console.WriteLine("\n Enter Employee Joining Date (DD/MM/YYYY)*");
             joiningDate = Input.GetJoiningDate();
            if (joiningDate == "0") isExit = true;
        }

        private static void JobTitle()
        {
            Console.WriteLine("\n Enter Job Title:");
           jobTitle = Input.GetRole();
            if (jobTitle == "0") isExit = true;

        }

        private static void Location()
        {
            Console.WriteLine("\n Enter Employee Location:");
            locationID = Input.GetLocation();
            if (locationID == 0) isExit = true;

        }

        private static void Department()
        {
            Console.WriteLine("\n Enter Employee Department:");
             department = Input.GetDepartment(jobTitle);
            if (department == "0") isExit = true;

        }

        private static void Manager()
        {
            Console.WriteLine("\n Enter the Name of the Manager for Employee:");
             manager = Console.ReadLine()!;
            if (manager == "0") isExit = true;

        }

        private static void Project()
        {
            Console.WriteLine("\n Enter the Project assigned to the Employee:");
             project = Console.ReadLine()!;
            if (project == "0") isExit = true;

        }


        private static Dictionary<string, Action> MethodList()
        {
            methodList.Add("1", EmployeeNumber);
            methodList.Add("2", FirstName);
            methodList.Add("3", LastName);
            methodList.Add("4", DOB);
            methodList.Add("5", Email);
            methodList.Add("6", Phone);
            methodList.Add("7", JoiningDate);
            methodList.Add("8", JobTitle);
            methodList.Add("9", Location);
            methodList.Add("10", Department);
            methodList.Add("11", Manager);
            methodList.Add("12", Project);

            return methodList;  
        }

        

        public static void Add()
        {
            
            Console.WriteLine("Initiating Employee Addition procedure,please type \"0\" to return to the previous menu anytime");      

            foreach(string key in methodList.Keys)
            {
                if (isExit) { 
                    isExit = false;
                    return; 
                }
                    methodList[key].Invoke();
            }
          
            

            EmployeeModel employee = new EmployeeModel {
                EmpNo=emp.ToUpper(),
                FirstName=firstName,
                LastName=lastName,
                DateOfBirth=dob,
                Email=email,
                MobileNumber=mobile,
                JoiningDate=joiningDate,
                LocationId=locationID,
                JobTitle=jobTitle,
                Department=department,
                Manager=manager,
                Project=project
            };
            EmployeeService employeeService = new EmployeeService();
            bool isSuccess= employeeService.Add(employee);
            if (isSuccess)
            {
                Console.WriteLine("\n Employee Added Successfully");
            }

        }



        public static void Update()
        {
            EmployeeService employeeService = new EmployeeService();
            List<EmployeeModel> emplist = employeeService.ViewAll();
            if (emplist.Count == 0)
            {
                Console.WriteLine("\n---------No Records found---------\n");
                return;
            }
            
            bool isUpdate = true;
            //int locationId = 0;
            EmployeeView.ViewAll();
            Console.WriteLine("Initiating Employee Updation procedure,please type \"exit\" to return to return to the previous menu anyime");

            Console.WriteLine("Enter the employee Number of the employee whose record needs to be updated:-");
            string emp = Input.GetId(1);
            if (emp == "0") return;


            while (isUpdate)
            {

            Console.WriteLine($"Select the field that you want to update for the employee with Employee Number {emp}");
            Console.WriteLine("0. End Updation \n1. First Name \n2. Last Name \n3. Date of Birth \n4. Email \n5. Mobile Number \n6. Joining Date \n7. Job Title \n8. Employee Location \n9. Employee Department \n10. Employee Manager \n11. Employee Project");

                string option = Console.ReadLine()!;
                bool isValidOption = false;

                while (true) {
                    if (option == "0") { isUpdate = false; break; }
                    isValidOption=Validation.ValidateOptions(option);
                    if (isValidOption)break;
                    option = Console.ReadLine()!;
                }
            
                


                foreach(string key in methodList.Keys)
                {
                    if (option.Equals("0"))
                    {
                        isExit = false;
                        break;
                    }
                    string keyCheck= (Convert.ToInt32(option) + 1).ToString();
                    if (keyCheck.Equals(key))
                    {
                        methodList[key].Invoke();
                        break;
                    }
                }
            

            }

            

            foreach (EmployeeModel employee in emplist)
            {
                if (employee.EmpNo == emp)
                {
                    if(!string.IsNullOrWhiteSpace(firstName))employee.FirstName = firstName;
                    if (!string.IsNullOrWhiteSpace(lastName))employee.LastName = lastName;
                    if (!string.IsNullOrWhiteSpace(dob)) employee.DateOfBirth = dob;
                    if (!string.IsNullOrWhiteSpace(email)) employee.Email = email;
                    if (!string.IsNullOrWhiteSpace(mobile)) employee.MobileNumber = mobile;
                    if (!string.IsNullOrWhiteSpace(joiningDate)) employee.JoiningDate = joiningDate;
                    if (locationID != 0) employee.LocationId = locationID;
                    if (!string.IsNullOrWhiteSpace(jobTitle)) employee.JobTitle = jobTitle;
                    if (!string.IsNullOrWhiteSpace(department)) employee.Department = department;
                    if (!string.IsNullOrWhiteSpace(manager)) employee.Manager = manager;
                    if (!string.IsNullOrWhiteSpace(project)) employee.Project = project;
                         
                }
            }

           bool isSuccess= employeeService.Edit(emplist);
            if (isSuccess)
            {
                Console.WriteLine($"Employee with employee number {emp} updated sucessfully");
            }

        }


        public static void Delete()
        {
            EmployeeService employeeService = new EmployeeService();
            int recordsCheck=EmployeeView.ViewAll();
            if (recordsCheck == 0) return;
            Console.WriteLine("Initiating Employee Deletion procedure,please type \"0\" to return to return to the previous menu anyime");
            Console.WriteLine("Enter the Employee Number:-");
            string empNo = Input.GetId(1);
            if (empNo == "0") return;
            bool isSuccess=employeeService.Delete(empNo);
            if (isSuccess)
            {
                Console.WriteLine("Employee Deleted Sucessfully");
            }
        }

    }
}
