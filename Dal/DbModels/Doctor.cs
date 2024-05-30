using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Doctor
{
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Education { get; set; }

    public string PhoneNumber { get; set; }

    public string EmailAddress { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; } = new List<DoctorSpecialization>();

    public virtual ICollection<DoctorSurgeryJournal> DoctorSurgeryJournals { get; set; } = new List<DoctorSurgeryJournal>();
}
