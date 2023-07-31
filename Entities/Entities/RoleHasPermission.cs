using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class RoleHasPermission
{
    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    //public virtual Permission Permission { get; set; } = null!;
}
