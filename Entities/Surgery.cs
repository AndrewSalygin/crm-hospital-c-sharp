using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Surgery
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

		public Surgery(int id, int patientId, DateTimeOffset? scheduledDateTime, DateTimeOffset? startTime,
			DateTimeOffset? endTime, string surgeryType, string surgicalProcedureDescription, bool emergency,
			bool isDeleted)
		{
			Id = id;
			PatientId = patientId;
			ScheduledDateTime = scheduledDateTime;
			StartTime = startTime;
			EndTime = endTime;
			SurgeryType = surgeryType;
			SurgicalProcedureDescription = surgicalProcedureDescription;
			Emergency = emergency;
			IsDeleted = isDeleted;
		}
	}
}
