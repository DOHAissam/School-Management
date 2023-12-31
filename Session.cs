using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool.Model
{
    public class Session
    {
        public int? Id { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
        public ICollection<Enroll>? Enorollment { get; set; } = new HashSet<Enroll>();
        public ICollection<TeacherSession>? teacherSessions { get; set; } = new HashSet<TeacherSession>();
    }
}
