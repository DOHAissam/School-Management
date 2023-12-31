using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Identity;
using ProjectSchool.Model;
using SchoolMangment.Utitities;
using SchoolProject.Repositres;
using SchooMangmentProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangment.Serviscse
{
    public class StudentServices : IStudentServices
    {
        private  UnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManager; // to create new user
        private RoleManager<IdentityRole> _roleManager;// to create new rolemanger 

        public StudentServices(UnitOfWork unitOfWork , UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;

        }
          


        public async Task AddStudent(CreatStudenViweModel studente)
        {
            ApplicationUser userApp = new ApplicationUser() 
            {
                UserName = studente.UserName,
                Email = studente.Email,
            };
            var Result = await _userManager.CreateAsync(userApp, studente.Password);
            if (Result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync("student"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("student"));
                }
                await _userManager.AddToRoleAsync(userApp, "student");

            }
            studente.KeyId = userApp.Id;
            var model = new CreatStudenViweModel().ConvertModel(studente);
            await _unitOfWork.GenenaricRepositry<Studente>().AddAsync(model);
            _unitOfWork.Save();   
        }

        public PagedResult<StudentViweModel> GetAll(int PageNumper, int PageSize)
        {
            var totalCount = 0;
            List<StudentViweModel> viweList = new();
            try
            {
                int EexCloudRecord = (PageNumper * PageSize)-PageSize;
                var modelList = _unitOfWork.GenenaricRepositry<Studente>().GetAll().Skip(EexCloudRecord).Take(PageSize).ToList();
                totalCount = _unitOfWork.GenenaricRepositry<Studente>().GetAll().ToList().Count();
                viweList = ConvertModelToViewModelList((List<Studente>)modelList);



            }
            catch (Exception ex) { throw; }
            {
                var Result = new PagedResult <StudentViweModel>()
                {
                    Data = viweList,
                    TotalItem = totalCount,
                    PageNunber = PageNumper,
                    PageSiza = PageSize

                };
                return Result;
            }
           
        }

        public int GettAllStudent()
        {
            int totalCount = _unitOfWork.GenenaricRepositry<Studente>().GetAll().ToList().Count();
            return totalCount;
        }

        private List<StudentViweModel> ConvertModelToViewModelList(List<Studente> modelList)
        {
            return modelList.Select(x => new StudentViweModel(x)).ToList();
        }
    }
}
