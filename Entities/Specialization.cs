using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Specialization
	{
		public int Id { get; set; }
		public string SpecializationName { get; set; }

		public Specialization(int id, string specializationName)
		{
			Id = id;
			SpecializationName = specializationName;
		}
	}
}
