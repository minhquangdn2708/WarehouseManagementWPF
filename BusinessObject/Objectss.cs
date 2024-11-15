using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Objectss
{
    public int ObjectId { get; set; }

    public string ObjectName { get; set; } = null!;

    public int UnitId { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
