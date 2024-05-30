using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Surgery
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTimeOffset? ScheduledDateTime { get; set; }

    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    public string SurgeryType { get; set; }

    public string SurgicalProcedureDescription { get; set; }

    public bool Emergency { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<DoctorSurgeryJournal> DoctorSurgeryJournals { get; set; } = new List<DoctorSurgeryJournal>();
}
