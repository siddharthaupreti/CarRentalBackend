using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class User
    {
        public User()
        {
            Institutes = new HashSet<Institute>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Institute> Institutes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
