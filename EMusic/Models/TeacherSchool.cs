using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class TeacherSchool
    {
        public TeacherSchool()
        {
            Courses = new HashSet<Course>();
        }

        public Guid TeacherSchoolId { get; set; }
        public Guid TeacherApplicationId { get; set; }
        public bool? TeacherActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual TeacherApplication TeacherApplication { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
    }
}
