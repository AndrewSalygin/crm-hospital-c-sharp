using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class DoctorSurgeryJournal
	{
		public int Id { get; set; }
		public int DoctorId { get; set; }
		public int SurgeryId { get; set; }
		public double? WorkingHours { get; set; }
		public double? ScheduledWorkingHours { get; set; }

		public DoctorSurgeryJournal(int id, int doctorId, int surgeryId, double? workingHours,
			double? scheduledWorkingHours)
		{
			Id = id;
			DoctorId = doctorId;
			SurgeryId = surgeryId;
			WorkingHours = workingHours;
			ScheduledWorkingHours = scheduledWorkingHours;
		}
	}
}
