using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common;
using ProjectSchool.Model;
using SchoolProject.Repositres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangment.Utitities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly  RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _context;

        public DbInitializer
        (
         UserManager<IdentityUser> userManger,
         RoleManager <IdentityRole> roleManager 
        ,ApplicationDBContext context)
        {
            _userManager = userManger;
            roleManager = _roleManager;
            context = _context;
          
        }
        public async void Initialize()
        {
           
                try
            {

                if(_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception) 
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSitRol.WibSit_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSitRol.WibSit_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSitRol.WibSit_Studente)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSitRol.WibSit_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSitRol.WibSit_Teacher)).GetAwaiter().GetResult();
                var result = _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"

                }, "Admin@1234").GetAwaiter().GetResult();
                var AppUser = _userManager.Users.Where(E => E.Email == "admin@gmail.com").FirstOrDefault();
                if (AppUser != null)
                {
                    _userManager.AddToRoleAsync(AppUser, WebSitRol.WibSit_Admin).GetAwaiter().GetResult();
                }

            }
           
        }
    }
}
