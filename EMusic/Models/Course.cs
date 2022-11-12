using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Course
    {
        public Course()
        {
            EnrollmentApplications = new HashSet<EnrollmentApplication>();
            Lessons = new HashSet<Lesson>();
        }

        public Guid CourseId { get; set; }
        public Guid TeacherSchoolId { get; set; }
        public string CourseTitle { get; set; } = null!;
        public string? CourseDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual TeacherSchool TeacherSchool { get; set; } = null!;
        public virtual ICollection<EnrollmentApplication> EnrollmentApplications { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
