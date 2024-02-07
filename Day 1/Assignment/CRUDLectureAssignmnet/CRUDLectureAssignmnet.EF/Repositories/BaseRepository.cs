using CRUDLectureAssignmnet.Core.Interface;
using CRUDLectureAssignmnet.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.EF.Repositories
{
    public class BaseRepository<T>(ApplicatioDbContext context) : IBaseRepository<T> where T : class
    {
        private readonly ApplicatioDbContext _context = context;


        #region Create Methods
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        #endregion

        #region Read Methods
        public IEnumerable<T> GetAll()
        {
            //If no items return empty list
            return _context.Set<T>().Any() ? _context.Set<T>().AsNoTracking().ToList() : Enumerable.Empty<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().Any() ? await _context.Set<T>().AsNoTracking().ToListAsync() : Enumerable.Empty<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T? GetByCriteria(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().FirstOrDefault(criteria);
        }

        public Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().FirstOrDefaultAsync(criteria);
        }

        #endregion

        #region Update Methods

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        #endregion

        #region Delete Methods
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        #endregion

    }
}
