using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool.Model
{
    public class Enroll
    {
       
        public int? Id { get; set; }
        public int? StudentId { get; set; }

        [NotMapped]
        public Studente? Studente { get; set; }
        public int? SessionId { get; set; }

        [NotMapped]
        public Session? Session { get; set; }
        
         public int? GraidId { get; set; }

        [NotMapped]
        public Grade? Grade { get; set; }

    }
}
