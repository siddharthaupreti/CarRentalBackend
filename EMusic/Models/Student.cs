using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Student
    {
        public Student()
        {
            EnrollmentApplications = new HashSet<EnrollmentApplication>();
            InstituteRatings = new HashSet<InstituteRating>();
            TeacherRatings = new HashSet<TeacherRating>();
        }

        public Guid StudentId { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? Password { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<EnrollmentApplication> EnrollmentApplications { get; set; }
        public virtual ICollection<InstituteRating> InstituteRatings { get; set; }
        public virtual ICollection<TeacherRating> TeacherRatings { get; set; }
    }
}
