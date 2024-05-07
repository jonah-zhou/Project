using System;
using System.Collections.Generic;

namespace PropertyRentalManagement.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PropertyManagerId { get; set; }

    public int TenantId { get; set; }

    public int ApartmentId { get; set; }

    public DateTime AppointmentDateTime { get; set; }

    public virtual Apartment? Apartment { get; set; }

    public virtual User? PropertyManager { get; set; }

    public virtual User? Tenant { get; set; }
}
