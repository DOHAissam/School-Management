using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ProjectSchool.Model
{
    public class AssignGrade 
    {

        [Key]
        public int Id { get; set; }
        public int? GradeId { get; set; }
        public Grade? Grade { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
