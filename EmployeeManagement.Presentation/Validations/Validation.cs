using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Presentation.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.Presentation.Validations
{
    public class Validation
    {
        static EmployeeService employeeService = new EmployeeService();

        public static bool ValidateId(string employeeNumber,int validation)
        {

            if (validation == 0)
            {
                List<EmployeeModel> empData = employeeService.ViewAll()!;
                if (empData.Count != 0)
                    {
                        EmployeeModel data= employeeService.ViewOne(employeeNumber)!;

                    if (employeeNumber == "")
                        {
                            Console.WriteLine("Employee Number cannot be null please re-enter the same");
                        return false;
                    }
                        else if (!Regex.IsMatch(employeeNumber, @"^TZ\d{4}"))
                        {
                            Console.WriteLine("Please enter valid Employee Number");
                        return false;
                    }
                        else if (data != null && data.EmpNo == employeeNumber)
                        {
                            Console.WriteLine("Cannot Enter Duplicate Employee Number,please enter a unique Number for the same.");
                        return false;
                        }
                        else return true;
                    }
                    else return true;
                

            }
            else if (validation == 1)
            {
                EmployeeModel data = employeeService.ViewOne(employeeNumber)!;

                if (employeeNumber == "")
                {
                    Console.WriteLine("Employee Number cannot be null please re-enter the same");
                    return false;
                }
                else if (!Regex.IsMatch(employeeNumber, @"^([a-zA-Z0-9]+)$")) {
                    Console.WriteLine("Please enter valid Employee Number"); 
                    return false;
                }
                else if(data==null)
                {
                    Console.WriteLine($"No employee with employee number {employeeNumber} found in the records,please ensure that the employee exists in the employee records");
                    return false;
                }
                return true;
            }
            return false;
        }


        public static bool ValidateNameTypeInput(string input,string inpType) {

            if (input == "")
            {
                Console.WriteLine($"{inpType} cannot be null please re-enter the same");
                return false;
            }
            else if (!Regex.IsMatch(input, @"^([a-zA-Z_ ]+)$"))
            {
                Console.WriteLine($"{inpType} should only contain Alphabet ");
                return false;
            }
            else {  
                return true;
            }

        }



        public static bool ValidateEmail(string email)
        {
           
                if (email == "") { 
                    Console.WriteLine("Email cannot be null please re-enter the same");
                    return false;
                }
                else if (!Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                {
                    Console.WriteLine("Please Enter a valid Email Id.");
                    return false;
                }
                else return true;
    
        }


        public static bool DateTypeInput(string date,string type)
        {

            if (date == "")
            {
                if (type == "Date of Birth") return true;
                Console.WriteLine($"{type} cannot be null please re-enter the same");
                return false;
            }
            else if (!Regex.IsMatch(date, @"\b(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}\b"))
            {
                Console.WriteLine($"Please Enter {type} in DD/MM/YYYY format.");
                return false;
            }
            else return true; 
                
        }


        public static bool ValidateOptions(string input)
        {
            
                if (input == "")
                {
                    Console.WriteLine("option cannot be null, please choose from the options provided.");
                    return false;
                }
                else if (!Regex.IsMatch(input, @"^([0-9]+)$"))
                {
                    Console.WriteLine("Option can only contain numbers.");
                    return false;

                }
              
                else return true;
        }


        public static bool ValidateMobileNumber(string mobileNumber)
        {

            if (mobileNumber != "" && !Regex.IsMatch(mobileNumber, @"^\d{10}$"))
            {
                Console.WriteLine("Please enter a valid phone number and ensure it is of 10 digits");
                return false;
            }

            else return true;
        }

        public static bool ValidateLocation(string locationName)
        {
            LocationService locationService = new LocationService();
            List<LocationModel> locationList = locationService.ViewAll();
            foreach(LocationModel location in locationList) {
                if (locationName == "" || locationName.ToUpper().Equals(location.LocationName.ToUpper()))
                {
                    return false;
                }
            }
            return true;

        }

    }
}
