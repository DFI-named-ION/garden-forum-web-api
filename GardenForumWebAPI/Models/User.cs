using System;
using System.Collections.Generic;

namespace GardenForumWebAPI.Models;

public partial class User
{
    public long Id { get; set; }

    public long RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime LastOnline { get; set; }

    public virtual ICollection<ArticleLike>? ArticleLikes { get; set; }

    public virtual ICollection<Article>? Articles { get; set; }

    public virtual ICollection<ReceiptLike>? ReceiptLikes { get; set; }

    public virtual ICollection<Receipt>? Receipts { get; set; }

    public virtual Role? Role { get; set; } = null!;
}
