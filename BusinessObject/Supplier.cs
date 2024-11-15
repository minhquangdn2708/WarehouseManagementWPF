using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateOnly? ContractDate { get; set; }

    public virtual ICollection<Objectss> Objectsses { get; set; } = new List<Objectss>();
}
