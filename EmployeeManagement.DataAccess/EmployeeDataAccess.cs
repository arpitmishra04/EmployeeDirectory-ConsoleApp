using System.Text.Json;
using EmployeeManagement.Model;
using Newtonsoft.Json;
namespace EmployeeManagement.DataAccess
{
    public class EmployeeDataAccess
    {
        public static string path = @"C:\Users\arpit.m\OneDrive - Technovert\Desktop\Tezo-tasks\classroom\Task-5\Employees.json";
        public static List<EmployeeModel> GetAll()
        {
            var data = File.ReadAllText(path);
           
            List<EmployeeModel> employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(data)!;
            return employees;
        }

        public static EmployeeModel GetOne(string employeeNumber)
        {
            var data = File.ReadAllText(path);
            List<EmployeeModel> employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(data)!;
            if (employees != null) { 
                EmployeeModel employee = employees.Find(emp => emp.EmpNo == employeeNumber)!;
                return employee;
            }
            return null!;
        }

        public static bool Update(List<EmployeeModel> employeeList)
        {
           
            return Set(employeeList);

        }

        public static bool Delete(string employeeNumber)
        {
            var data = File.ReadAllText(path);
            List<EmployeeModel> employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(data)!;
            employees.Remove(employees.Find(emp => emp.EmpNo == employeeNumber)!);
            return Set(employees);

        }
        public static bool Set(List<EmployeeModel> employeeList)
        {
            var data = File.ReadAllText(path);
            string employees = JsonConvert.SerializeObject(employeeList)!;
            File.WriteAllText(path, employees);
            return true;
        }
    }
}
