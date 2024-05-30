using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using DoctorSurgeryJournal = Entities.DoctorSurgeryJournal;

namespace BL
{
	public class doctorSurgeryJournalBL
	{
		public async Task<int> AddOrUpdateAsync(DoctorSurgeryJournal entity)
		{
			entity.Id = await new doctorSurgeryJournalDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new doctorSurgeryJournalDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(doctorSurgeryJournalSearchParams searchParams)
		{
			return new doctorSurgeryJournalDal().ExistsAsync(searchParams);
		}

		public Task<DoctorSurgeryJournal> GetAsync(int id)
		{
			return new doctorSurgeryJournalDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new doctorSurgeryJournalDal().DeleteAsync(id);
		}

		public Task<SearchResult<DoctorSurgeryJournal>> GetAsync(doctorSurgeryJournalSearchParams searchParams)
		{
			return new doctorSurgeryJournalDal().GetAsync(searchParams);
		}
	}
}

