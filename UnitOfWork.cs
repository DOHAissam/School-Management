using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Repositres
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
      private readonly ApplicationDBContext _dbContext;
        public UnitOfWork(ApplicationDBContext context)
        {
            _dbContext = context;
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
                    _dbContext.Dispose();
                }

            }
            this.disposed = true;
        }


        public IGenenaricRepositry<T> GenenaricRepositry<T>() where T : class
        {
            IGenenaricRepositry<T> repo = new GenenaricRepositry<T>(_dbContext);
            return repo;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
