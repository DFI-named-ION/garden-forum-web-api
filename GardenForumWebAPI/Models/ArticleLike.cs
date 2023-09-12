using System;
using System.Collections.Generic;

namespace GardenForumWebAPI.Models;

public partial class ArticleLike
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long ArticleId { get; set; }

    public DateTime Publish { get; set; }

    public virtual Article? Article { get; set; } = null!;

    public virtual User? User { get; set; }
}
