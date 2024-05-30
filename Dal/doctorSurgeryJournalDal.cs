using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class doctorSurgeryJournalDal : BaseDal<DefaultDbContext, DoctorSurgeryJournal, Entities.DoctorSurgeryJournal, int, doctorSurgeryJournalSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public doctorSurgeryJournalDal()
		{
		}

		protected internal doctorSurgeryJournalDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.DoctorSurgeryJournal entity, DoctorSurgeryJournal dbObject, bool exists)
		{
			dbObject.DoctorId = entity.DoctorId;
			dbObject.SurgeryId = entity.SurgeryId;
			dbObject.WorkingHours = entity.WorkingHours;
			dbObject.ScheduledWorkingHours = entity.ScheduledWorkingHours;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<DoctorSurgeryJournal>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<DoctorSurgeryJournal> dbObjects, doctorSurgeryJournalSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.DoctorSurgeryJournal>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<DoctorSurgeryJournal> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<DoctorSurgeryJournal, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.DoctorSurgeryJournal, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.DoctorSurgeryJournal ConvertDbObjectToEntity(DoctorSurgeryJournal dbObject)
		{
			return dbObject == null ? null : new Entities.DoctorSurgeryJournal(dbObject.Id, dbObject.DoctorId,
				dbObject.SurgeryId, dbObject.WorkingHours, dbObject.ScheduledWorkingHours);
		}
	}
}
