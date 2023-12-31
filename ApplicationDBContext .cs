using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SchoolProject.Repositres
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    
    { 


   
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Studente> Studente { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AssignGrade> AssignGrade { get; set; }
        public DbSet<Enroll> Enroll { get; set; }
        public DbSet<Session> yearlySession { get; set; }
        public DbSet<Grade> Grades { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AssignGrade>().HasOne(x => x.Grade).WithMany(z => z.AssignGrades).HasForeignKey(x => x.GradeId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<AssignGrade>().HasOne(x => x.Teacher).WithMany(z => z.AssignGrades).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Enroll>().HasOne(x => x.Studente).WithMany(z => z.YearlySession).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Enroll>().HasOne(x => x.Session).WithMany(z => z.Enorollment).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Enroll>().HasOne(x => x.Grade).WithMany(z => z.Enrolls).HasForeignKey(x => x.GraidId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<TeacherSession>().HasOne(x => x.Teacher).WithMany(z => z.TeachrSession).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<TeacherSession>().HasOne(x => x.Session).WithMany(z => z.teacherSessions).HasForeignKey(x => x.SessionId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
