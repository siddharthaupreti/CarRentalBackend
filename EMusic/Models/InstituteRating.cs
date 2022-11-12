using System;
using System.Collections.Generic;

namespace EMusic.Models
{
    public partial class InstituteRating
    {
        public Guid InstituteRatingId { get; set; }
        public Guid StudentId { get; set; }
        public Guid InstituteId { get; set; }
        public int? Rating { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Institute Institute { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
