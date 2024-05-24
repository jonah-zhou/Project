using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Models;

public partial class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserType { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Appointment> AppointmentPropertyManagers { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentTenants { get; set; } = new List<Appointment>();

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual Status? Status { get; set; }

    public virtual UserType? UserTypeNavigation { get; set; }
}
