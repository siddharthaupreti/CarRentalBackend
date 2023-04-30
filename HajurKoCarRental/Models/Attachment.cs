using System;
using System.Collections.Generic;

namespace EMusic.Models;

public partial class Attachment
{
    public Guid AttachmentId { get; set; }

    public byte[] Attachment1 { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
