using System;
using System.Collections.Generic;

namespace SchoolManegment.Data;

public partial class Appartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Details { get; set; } = null!;

    public int NumberOfRooms { get; set; }

    public string ImgUrl { get; set; } = null!;

    public int Rate { get; set; }

    public double Area { get; set; }

    public virtual ICollection<AppartmentNumber> AppartmentNumbers { get; } = new List<AppartmentNumber>();
}
