using System;
using System.Collections.Generic;

namespace GardenForumWebAPI.Models;

public partial class Role
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<User>? Users { get; set; }
}
