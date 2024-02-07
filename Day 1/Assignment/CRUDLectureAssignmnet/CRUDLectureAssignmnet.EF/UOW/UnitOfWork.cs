using CRUDLectureAssignmnet.Core.Interface;
using CRUDLectureAssignmnet.Core.Model;
using CRUDLectureAssignmnet.EF.Context;
using CRUDLectureAssignmnet.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.EF.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicatioDbContext _context;

        public UnitOfWork(ApplicatioDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
        }
        public IBaseRepository<Employee> Employees { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
