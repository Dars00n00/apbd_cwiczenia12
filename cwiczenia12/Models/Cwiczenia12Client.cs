using System;
using System.Collections.Generic;


namespace cwiczenia12.Models;


public partial class Cwiczenia12Client
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Pesel { get; set; } = null!;

    public virtual ICollection<Cwiczenia12ClientTrip> Cwiczenia12ClientTrips { get; set; } = new List<Cwiczenia12ClientTrip>();
}
