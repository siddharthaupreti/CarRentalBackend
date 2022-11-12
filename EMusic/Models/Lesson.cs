using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonEnrollments = new HashSet<LessonEnrollment>();
        }

        public Guid LessonId { get; set; }
        public Guid CourseId { get; set; }
        public string LessonDescription { get; set; } = null!;
        public byte[] LessonVideo { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<LessonEnrollment> LessonEnrollments { get; set; }
    }
}
