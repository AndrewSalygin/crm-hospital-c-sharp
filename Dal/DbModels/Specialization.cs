using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Specialization
{
    public int Id { get; set; }

    public string SpecializationName { get; set; }

    public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; } = new List<DoctorSpecialization>();
}
