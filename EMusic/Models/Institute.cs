using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class Institute
    {
        public Institute()
        {
            InstituteRatings = new HashSet<InstituteRating>();
            TeacherApplications = new HashSet<TeacherApplication>();
        }

        public Guid InstituteId { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? EstablishedYear { get; set; }
        public string? Description { get; set; }
        public byte[]? Password { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<InstituteRating> InstituteRatings { get; set; }
        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }
    }
}
