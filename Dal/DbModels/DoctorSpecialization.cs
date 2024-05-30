using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class DoctorSpecialization
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int SpecializationId { get; set; }

    public int YearsOfExperience { get; set; }

    public virtual Doctor Doctor { get; set; }

    public virtual Specialization Specialization { get; set; }
}
