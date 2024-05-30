using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class DoctorSurgeryJournal
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int SurgeryId { get; set; }

    public double? WorkingHours { get; set; }

    public double? ScheduledWorkingHours { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual Surgery Surgery { get; set; }
}
