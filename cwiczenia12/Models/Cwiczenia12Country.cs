using System;
using System.Collections.Generic;


namespace cwiczenia12.Models;


public partial class Cwiczenia12Country
{
    public int IdCountry { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cwiczenia12Trip> IdTrips { get; set; } = new List<Cwiczenia12Trip>();
}
