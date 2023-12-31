using SchoolMangment.Utitities;
using SchooMangmentProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangment.Serviscse
{
    public interface IStudentServices
    {
        Task AddStudent(CreatStudenViweModel studente);
        PagedResult<StudentViweModel> GetAll(int PagrNumper, int PageSize);
        int GettAllStudent();

    }
}
