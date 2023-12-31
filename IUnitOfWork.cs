using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Repositres
{
    public interface IUnitOfWork
    {
        IGenenaricRepositry<T> GenenaricRepositry<T>() where T : class;
        void Save();
    }
}
