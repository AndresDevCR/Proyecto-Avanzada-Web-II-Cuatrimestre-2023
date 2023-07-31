using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class UserHasApplication
{
    public int UserId { get; set; }

    public int ApplicationId { get; set; }

    //public virtual Application Application { get; set; } = null!;
}
