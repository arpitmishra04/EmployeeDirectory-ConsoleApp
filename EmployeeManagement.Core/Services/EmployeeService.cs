using EmployeeManagement.Model;
using System.Text.RegularExpressions;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        List<EmployeeModel> employeeList = EmployeeDataAccess.GetAll();
        public bool Add(EmployeeModel employee)
        {
            if (employeeList == null)
            {
                employeeList = new List<EmployeeModel>();
            }
            employeeList.Add(employee);
            return EmployeeDataAccess.Set(employeeList); ;
        }


        public bool Delete(string employeeNumber)
        {
            return EmployeeDataAccess.Delete(employeeNumber);
        }

        public bool Edit(List<EmployeeModel> employeeList)
        {
            return EmployeeDataAccess.Update(employeeList);
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> ViewAll()
        {
            return EmployeeDataAccess.GetAll();
        }

        public EmployeeModel ViewOne(string employeeNumber)
        {
            return EmployeeDataAccess.GetOne(employeeNumber);
        }


    }
}
