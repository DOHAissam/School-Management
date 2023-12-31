using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Repositres
{
    public class GenenaricRepositry<T> : IDisposable, IGenenaricRepositry<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        internal DbSet<T> dbSet;
        public GenenaricRepositry( ApplicationDBContext context) 
        {
            _context = context; 
            dbSet = context.Set<T>();   
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

            }
            this.disposed = true;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void AddRange(List<T> entity)
        {
            dbSet.AddRange(entity);
        }

        public void Delete(T entity)
        {
            if(_context.Entry(entity).State== EntityState.Detached)
            {
            dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public async Task<T> DeleteAcync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
           dbSet.Remove(entity);
            return entity;
        }

        public void DeleteRange(List<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

      
        public bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return dbSet.All(filter);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> Include = null, bool disableTraking = true)
        {
            IQueryable<T> quiry = dbSet;
            if (disableTraking)
            {
                quiry = quiry.AsNoTracking();
                
            }
            if (filter != null)
            {
                quiry = quiry.Where(filter);
            }
            if(Include!= null)
            {
                quiry= Include(quiry);
            }
            if(orderBy != null)
            {
                return quiry.ToList();
            }
            else
            {
                return quiry.ToList();
            }
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public T GetIdByAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> Include = null, bool disableTraking = true)
        {
            IQueryable<T> query = dbSet;    
            if (disableTraking)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(Include != null)
            {
                query = Include(query);
            }
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
         dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
        }

        public async Task<T> UpdateAcync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
