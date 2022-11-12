using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            LessonEnrollments = new HashSet<LessonEnrollment>();
        }

        public Guid EnrollmentId { get; set; }
        public Guid EnrollmentApplicationId { get; set; }
        public bool Status { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual EnrollmentApplication EnrollmentApplication { get; set; } = null!;
        public virtual ICollection<LessonEnrollment> LessonEnrollments { get; set; }
    }
}
