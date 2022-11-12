using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class LessonEnrollment
    {
        public Guid LessonEnrollmentId { get; set; }
        public Guid LessonId { get; set; }
        public Guid EnrollmentId { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
        public virtual Lesson Lesson { get; set; } = null!;
    }
}
