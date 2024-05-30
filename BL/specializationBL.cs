using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Specialization = Entities.Specialization;

namespace BL
{
	public class specializationBL
	{
		public async Task<int> AddOrUpdateAsync(Specialization entity)
		{
			entity.Id = await new specializationDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new specializationDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(specializationSearchParams searchParams)
		{
			return new specializationDal().ExistsAsync(searchParams);
		}

		public Task<Specialization> GetAsync(int id)
		{
			return new specializationDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new specializationDal().DeleteAsync(id);
		}

		public Task<SearchResult<Specialization>> GetAsync(specializationSearchParams searchParams)
		{
			return new specializationDal().GetAsync(searchParams);
		}
	}
}

