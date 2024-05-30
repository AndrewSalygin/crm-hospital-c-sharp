using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Surgery = Entities.Surgery;

namespace BL
{
	public class surgeryBL
	{
		public async Task<int> AddOrUpdateAsync(Surgery entity)
		{
			entity.Id = await new surgeryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new surgeryDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(surgerySearchParams searchParams)
		{
			return new surgeryDal().ExistsAsync(searchParams);
		}

		public Task<Surgery> GetAsync(int id)
		{
			return new surgeryDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new surgeryDal().DeleteAsync(id);
		}

		public Task<SearchResult<Surgery>> GetAsync(surgerySearchParams searchParams)
		{
			return new surgeryDal().GetAsync(searchParams);
		}
	}
}

