using System;
using System.Collections.Generic;

namespace SchoolManegment.Data;

public partial class AppartmentNumber
{
    public int AppartmentNo { get; set; }

    public string SpecialDetails { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int AppartmentId { get; set; }

    public virtual Appartment Appartment { get; set; } = null!;
}
