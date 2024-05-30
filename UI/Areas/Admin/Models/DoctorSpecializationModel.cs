using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DoctorSpecializationModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DoctorId")]
		public int DoctorId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SpecializationId")]
		public int SpecializationId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "YearsOfExperience")]
		public int YearsOfExperience { get; set; }

		public static DoctorSpecializationModel FromEntity(DoctorSpecialization obj)
		{
			return obj == null ? null : new DoctorSpecializationModel
			{
				Id = obj.Id,
				DoctorId = obj.DoctorId,
				SpecializationId = obj.SpecializationId,
				YearsOfExperience = obj.YearsOfExperience,
			};
		}

		public static DoctorSpecialization ToEntity(DoctorSpecializationModel obj)
		{
			return obj == null ? null : new DoctorSpecialization(obj.Id, obj.DoctorId, obj.SpecializationId,
				obj.YearsOfExperience);
		}

		public static List<DoctorSpecializationModel> FromEntitiesList(IEnumerable<DoctorSpecialization> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<DoctorSpecialization> ToEntitiesList(IEnumerable<DoctorSpecializationModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
