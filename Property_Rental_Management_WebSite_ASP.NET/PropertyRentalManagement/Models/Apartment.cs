using System;
using System.Collections.Generic;

namespace PropertyRentalManagement.Models;

public partial class Apartment
{
    public int ApartmentId { get; set; }

    public int BuildingId { get; set; }

    public int ApartmentNumber { get; set; }

    public int StatusId { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Building? Building { get; set; }

    public virtual Status? Status { get; set; }
}
