using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class EmployeeModel
    {
        public required string EmpNo { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string MobileNumber { get; set; }
        public required string JoiningDate { get; set; }
        public required int LocationId { get; set; }
        public required string JobTitle { get; set; }
        public required string Department { get; set; }
        public required string Manager { get; set; }
        public required string Project { get; set; }

    }
}
