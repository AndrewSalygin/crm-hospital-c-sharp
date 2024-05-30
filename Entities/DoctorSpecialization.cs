using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class DoctorSpecialization
	{
		public int Id { get; set; }
		public int DoctorId { get; set; }
		public int SpecializationId { get; set; }
		public int YearsOfExperience { get; set; }

		public DoctorSpecialization(int id, int doctorId, int specializationId, int yearsOfExperience)
		{
			Id = id;
			DoctorId = doctorId;
			SpecializationId = specializationId;
			YearsOfExperience = yearsOfExperience;
		}
	}
}
