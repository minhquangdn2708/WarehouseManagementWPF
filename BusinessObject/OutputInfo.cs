using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class OutputInfo
{
    public int OutputInfoId { get; set; }

    public int CustomerId { get; set; }

    public int ObjectId { get; set; }

    public int InputInfoId { get; set; }

    public int Count { get; set; }

    public DateOnly OutputDate { get; set; }

    public string? Status { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual InputInfo InputInfo { get; set; } = null!;

    public virtual Objectss Object { get; set; } = null!;
}
