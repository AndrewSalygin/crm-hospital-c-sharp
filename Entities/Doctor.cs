using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Doctor
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

		public Doctor(int id, string lastName, string firstName, string middleName, DateTime dateOfBirth,
			string gender, string education, string phoneNumber, string emailAddress, bool isDeleted)
		{
			Id = id;
			LastName = lastName;
			FirstName = firstName;
			MiddleName = middleName;
			DateOfBirth = dateOfBirth;
			Gender = gender;
			Education = education;
			PhoneNumber = phoneNumber;
			EmailAddress = emailAddress;
			IsDeleted = isDeleted;
		}
	}
}
