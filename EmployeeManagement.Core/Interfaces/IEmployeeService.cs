using EmployeeManagement.Model;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        bool Add(EmployeeModel employee);
        bool Delete(string employeeNumber);
        bool Edit(List<EmployeeModel> employeeList);
        void GoBack();
        List<EmployeeModel> ViewAll();
        EmployeeModel ViewOne(string employeeNumber);
    }
}