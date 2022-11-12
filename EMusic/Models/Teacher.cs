using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            TeacherApplications = new HashSet<TeacherApplication>();
            TeacherFaculties = new HashSet<TeacherFaculty>();
            TeacherRatings = new HashSet<TeacherRating>();
        }

        public Guid TeacherId { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public byte[]? Password { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }
        public virtual ICollection<TeacherFaculty> TeacherFaculties { get; set; }
        public virtual ICollection<TeacherRating> TeacherRatings { get; set; }
    }
}
