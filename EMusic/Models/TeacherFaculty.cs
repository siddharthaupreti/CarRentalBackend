using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class TeacherFaculty
    {
        public Guid TeacherFacultyId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
