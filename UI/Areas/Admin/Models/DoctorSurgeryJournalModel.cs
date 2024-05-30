using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DoctorSurgeryJournalModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DoctorId")]
		public int DoctorId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SurgeryId")]
		public int SurgeryId { get; set; }

		[Display(Name = "WorkingHours")]
		public double? WorkingHours { get; set; }

		[Display(Name = "ScheduledWorkingHours")]
		public double? ScheduledWorkingHours { get; set; }

		public static DoctorSurgeryJournalModel FromEntity(DoctorSurgeryJournal obj)
		{
			return obj == null ? null : new DoctorSurgeryJournalModel
			{
				Id = obj.Id,
				DoctorId = obj.DoctorId,
				SurgeryId = obj.SurgeryId,
				WorkingHours = obj.WorkingHours,
				ScheduledWorkingHours = obj.ScheduledWorkingHours,
			};
		}

		public static DoctorSurgeryJournal ToEntity(DoctorSurgeryJournalModel obj)
		{
			return obj == null ? null : new DoctorSurgeryJournal(obj.Id, obj.DoctorId, obj.SurgeryId, obj.WorkingHours,
				obj.ScheduledWorkingHours);
		}

		public static List<DoctorSurgeryJournalModel> FromEntitiesList(IEnumerable<DoctorSurgeryJournal> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<DoctorSurgeryJournal> ToEntitiesList(IEnumerable<DoctorSurgeryJournalModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
