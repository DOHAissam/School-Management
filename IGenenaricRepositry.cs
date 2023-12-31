using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Repositres
{
    public interface IGenenaricRepositry<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> Include = null, bool disableTraking = true);

        T GetById(object id );
        T GetIdByAsync(Expression<Func<T , bool>> filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> Include = null,
            bool disableTraking = true
            );
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void AddRange(List<T> entity); 
        void Update(T entity);  
        Task<T> UpdateAcync(T entity);
        void Delete(T entity);
        Task<T> DeleteAcync(T entity);
        void DeleteRange(List<T> entity);
        bool Exists(Expression<Func<T, bool>> filter = null);
           

    }
}
