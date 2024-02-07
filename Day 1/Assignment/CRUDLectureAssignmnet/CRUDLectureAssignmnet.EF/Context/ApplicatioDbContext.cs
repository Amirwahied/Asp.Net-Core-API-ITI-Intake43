using CRUDLectureAssignmnet.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.EF.Context
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext()
        {

        }

        public ApplicatioDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Employee> Employees { get; set; }
    }
}
