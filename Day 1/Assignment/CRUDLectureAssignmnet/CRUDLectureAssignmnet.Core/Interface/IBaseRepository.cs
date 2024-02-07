using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDLectureAssignmnet.Core.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        #region Create Methods
        //Create new item
        T Create(T entity);
        Task<T> CreateAsync(T entity);
        #endregion

        #region Read Methods
        //Get single item with id
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);

        //Get single item with criteria (send dynamic query)
        T? GetByCriteria(Expression<Func<T, bool>> criteria);
        Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria);

        //Get all items
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        #endregion

        #region Update Methods
        //Update single item
        T Update(T entity);
        #endregion

        #region Delete Methods
        //Delete single item
        void Delete(T entity);
        #endregion


    }
}
