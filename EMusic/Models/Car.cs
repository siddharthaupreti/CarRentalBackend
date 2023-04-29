using System;
using System.Collections.Generic;

namespace EMusic.Models;

public partial class Car
{
    public Guid CarId { get; set; }

    public string CarModel { get; set; } = null!;

    public string CarYear { get; set; } = null!;

    public string CarCompany { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] CarImage { get; set; } = null!;

    public decimal PricePerday { get; set; }

    public Guid CarStatusId { get; set; }

    public virtual CurrentStatus CarStatus { get; set; } = null!;
}
