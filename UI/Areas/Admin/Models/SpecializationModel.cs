using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SpecializationModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SpecializationName")]
		public string SpecializationName { get; set; }

		public static SpecializationModel FromEntity(Specialization obj)
		{
			return obj == null ? null : new SpecializationModel
			{
				Id = obj.Id,
				SpecializationName = obj.SpecializationName,
			};
		}

		public static Specialization ToEntity(SpecializationModel obj)
		{
			return obj == null ? null : new Specialization(obj.Id, obj.SpecializationName);
		}

		public static List<SpecializationModel> FromEntitiesList(IEnumerable<Specialization> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Specialization> ToEntitiesList(IEnumerable<SpecializationModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
