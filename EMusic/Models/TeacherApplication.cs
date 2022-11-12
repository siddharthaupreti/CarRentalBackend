using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class TeacherApplication
    {
        public TeacherApplication()
        {
            TeacherSchools = new HashSet<TeacherSchool>();
        }

        public Guid TeacherApplicationId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid InstituteId { get; set; }
        public byte[]? DescriptionVideo { get; set; }
        public bool Status { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Institute Institute { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<TeacherSchool> TeacherSchools { get; set; }
    }
}
