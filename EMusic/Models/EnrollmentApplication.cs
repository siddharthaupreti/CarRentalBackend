using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class EnrollmentApplication
    {
        public EnrollmentApplication()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public Guid EnrollmentApplicationId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public bool Status { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
