using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class TeacherRating
    {
        public Guid TeacherRatingId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public int Rating { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
