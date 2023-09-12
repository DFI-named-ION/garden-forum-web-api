using System;
using System.Collections.Generic;

namespace GardenForumWebAPI.Models;

public partial class Receipt
{
    public long Id { get; set; }

    public string ShortTitle { get; set; } = null!;

    public string? Title { get; set; }

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }

    public string? Body { get; set; }

    public long? AuthorId { get; set; }

    public DateTime Publish { get; set; }

    public virtual User? Author { get; set; }

    public virtual ICollection<ReceiptLike>? ReceiptLikes { get; set; }
}
