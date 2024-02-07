using CRUDLectureAssignmnet.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.Core.DTO
{
    public class EmployeeDTO
    {
        public required string Name { get; set; }
        public decimal Salary { get; set; }
        public Employee ToEmployee()
        {
            return new Employee { Name = this.Name, Salary = this.Salary };
        }
        public Employee ToEmployee(int id)
        {
            return new Employee { Id = id, Name = this.Name, Salary = this.Salary };
        }
    }

}
