using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using DoctorSpecialization = Entities.DoctorSpecialization;

namespace BL
{
	public class doctorSpecializationBL
	{
		public async Task<int> AddOrUpdateAsync(DoctorSpecialization entity)
		{
			entity.Id = await new doctorSpecializationDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new doctorSpecializationDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(doctorSpecializationSearchParams searchParams)
		{
			return new doctorSpecializationDal().ExistsAsync(searchParams);
		}

		public Task<DoctorSpecialization> GetAsync(int id)
		{
			return new doctorSpecializationDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new doctorSpecializationDal().DeleteAsync(id);
		}

		public Task<SearchResult<DoctorSpecialization>> GetAsync(doctorSpecializationSearchParams searchParams)
		{
			return new doctorSpecializationDal().GetAsync(searchParams);
		}
	}
}

