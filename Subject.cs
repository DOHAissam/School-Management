

using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSchool.Model
{
    public class Subject
    {
        public int? Id { get; set; } 
        public string? Name { get; set; }
        [NotMapped]
        public ICollection<GradeSubject>? GradesSubject { get; set; }
    }
}