using System;
using System.Collections.Generic;

namespace GardenForumWebAPI.Models;

public partial class ReceiptLike
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long ReceiptId { get; set; }

    public DateTime Publish { get; set; }

    public virtual Receipt? Receipt { get; set; } = null!;

    public virtual User? User { get; set; }
}
