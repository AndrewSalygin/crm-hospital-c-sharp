using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Doctor = Entities.Doctor;

namespace BL
{
	public class doctorBL
	{
		public async Task<int> AddOrUpdateAsync(Doctor entity)
		{
			entity.Id = await new doctorDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new doctorDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(doctorSearchParams searchParams)
		{
			return new doctorDal().ExistsAsync(searchParams);
		}

		public Task<Doctor> GetAsync(int id)
		{
			return new doctorDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new doctorDal().DeleteAsync(id);
		}

		public Task<SearchResult<Doctor>> GetAsync(doctorSearchParams searchParams)
		{
			return new doctorDal().GetAsync(searchParams);
		}
	}
}

