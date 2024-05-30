using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DoctorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "MiddleName")]
		public string MiddleName { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "DateOfBirth")]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Gender")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Education")]
		public string Education { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "PhoneNumber")]
		public string PhoneNumber { get; set; }

		[Display(Name = "EmailAddress")]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "IsDeleted")]
		public bool IsDeleted { get; set; }

		public static DoctorModel FromEntity(Doctor obj)
		{
			return obj == null ? null : new DoctorModel
			{
				Id = obj.Id,
				LastName = obj.LastName,
				FirstName = obj.FirstName,
				MiddleName = obj.MiddleName,
				DateOfBirth = obj.DateOfBirth,
				Gender = obj.Gender,
				Education = obj.Education,
				PhoneNumber = obj.PhoneNumber,
				EmailAddress = obj.EmailAddress,
				IsDeleted = obj.IsDeleted,
			};
		}

		public static Doctor ToEntity(DoctorModel obj)
		{
			return obj == null ? null : new Doctor(obj.Id, obj.LastName, obj.FirstName, obj.MiddleName,
				obj.DateOfBirth, obj.Gender, obj.Education, obj.PhoneNumber, obj.EmailAddress, obj.IsDeleted);
		}

		public static List<DoctorModel> FromEntitiesList(IEnumerable<Doctor> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Doctor> ToEntitiesList(IEnumerable<DoctorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
