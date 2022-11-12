using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            TeacherFaculties = new HashSet<TeacherFaculty>();
        }

        public Guid FacultyId { get; set; }
        public string FacultyName { get; set; } = null!;

        public virtual ICollection<TeacherFaculty> TeacherFaculties { get; set; }
    }
}
