using CRUDLectureAssignmnet.Core.Model;
using CRUDLectureAssignmnet.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ApplicatioDbContext context) : base(context)
        {
        }
    }
}
