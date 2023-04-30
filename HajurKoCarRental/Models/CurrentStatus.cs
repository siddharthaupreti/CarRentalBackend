using System;
using System.Collections.Generic;

namespace EMusic.Models;

public partial class CurrentStatus
{
    public Guid CurrentStatusId { get; set; }

    public string CurrentStatus1 { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
