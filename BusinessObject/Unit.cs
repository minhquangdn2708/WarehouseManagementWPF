using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<Objectss> Objectsses { get; set; } = new List<Objectss>();
}
