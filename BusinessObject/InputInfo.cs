using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class InputInfo
{
    public int InputInfoId { get; set; }

    public int ObjectId { get; set; }

    public int Count { get; set; }

    public int InputPrice { get; set; }

    public int OutputPrice { get; set; }

    public DateOnly InputDate { get; set; }

    public string? Status { get; set; }

    public virtual Objectss Object { get; set; } = null!;

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
