using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SurgeryModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "PatientId")]
		public int PatientId { get; set; }

		[Display(Name = "ScheduledDateTime")]
		public DateTimeOffset? ScheduledDateTime { get; set; }

		[Display(Name = "StartTime")]
		public DateTimeOffset? StartTime { get; set; }

		[Display(Name = "EndTime")]
		public DateTimeOffset? EndTime { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SurgeryType")]
		public string SurgeryType { get; set; }

		[Display(Name = "SurgicalProcedureDescription")]
		public string SurgicalProcedureDescription { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Emergency")]
		public bool Emergency { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "IsDeleted")]
		public bool IsDeleted { get; set; }

		public static SurgeryModel FromEntity(Surgery obj)
		{
			return obj == null ? null : new SurgeryModel
			{
				Id = obj.Id,
				PatientId = obj.PatientId,
				ScheduledDateTime = obj.ScheduledDateTime,
				StartTime = obj.StartTime,
				EndTime = obj.EndTime,
				SurgeryType = obj.SurgeryType,
				SurgicalProcedureDescription = obj.SurgicalProcedureDescription,
				Emergency = obj.Emergency,
				IsDeleted = obj.IsDeleted,
			};
		}

		public static Surgery ToEntity(SurgeryModel obj)
		{
			return obj == null ? null : new Surgery(obj.Id, obj.PatientId, obj.ScheduledDateTime, obj.StartTime,
				obj.EndTime, obj.SurgeryType, obj.SurgicalProcedureDescription, obj.Emergency, obj.IsDeleted);
		}

		public static List<SurgeryModel> FromEntitiesList(IEnumerable<Surgery> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Surgery> ToEntitiesList(IEnumerable<SurgeryModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
