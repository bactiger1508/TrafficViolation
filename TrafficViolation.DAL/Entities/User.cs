﻿using System;
using System.Collections.Generic;

namespace TrafficViolation.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Report> ReportProcessedByNavigations { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportReporters { get; set; } = new List<Report>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
