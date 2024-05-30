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
	public class surgeryDal : BaseDal<DefaultDbContext, Surgery, Entities.Surgery, int, surgerySearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public surgeryDal()
		{
		}

		protected internal surgeryDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Surgery entity, Surgery dbObject, bool exists)
		{
			dbObject.PatientId = entity.PatientId;
			dbObject.ScheduledDateTime = entity.ScheduledDateTime;
			dbObject.StartTime = entity.StartTime;
			dbObject.EndTime = entity.EndTime;
			dbObject.SurgeryType = entity.SurgeryType;
			dbObject.SurgicalProcedureDescription = entity.SurgicalProcedureDescription;
			dbObject.Emergency = entity.Emergency;
			dbObject.IsDeleted = entity.IsDeleted;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Surgery>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Surgery> dbObjects, surgerySearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Surgery>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Surgery> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Surgery, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Surgery, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Surgery ConvertDbObjectToEntity(Surgery dbObject)
		{
			return dbObject == null ? null : new Entities.Surgery(dbObject.Id, dbObject.PatientId,
				dbObject.ScheduledDateTime, dbObject.StartTime, dbObject.EndTime, dbObject.SurgeryType,
				dbObject.SurgicalProcedureDescription, dbObject.Emergency, dbObject.IsDeleted);
		}
	}
}
