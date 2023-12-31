using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool.Model
{
    public class Studente
    {
       
        public int? Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public bool? Selectes { get; set; }
        [Unique]
        public string? KeyId { get; set; }
        public ICollection<Enroll>? YearlySession { get; set; }



    }
}
