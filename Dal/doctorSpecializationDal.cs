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
	public class doctorSpecializationDal : BaseDal<DefaultDbContext, DoctorSpecialization, Entities.DoctorSpecialization, int, doctorSpecializationSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public doctorSpecializationDal()
		{
		}

		protected internal doctorSpecializationDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.DoctorSpecialization entity, DoctorSpecialization dbObject, bool exists)
		{
			dbObject.DoctorId = entity.DoctorId;
			dbObject.SpecializationId = entity.SpecializationId;
			dbObject.YearsOfExperience = entity.YearsOfExperience;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<DoctorSpecialization>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<DoctorSpecialization> dbObjects, doctorSpecializationSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.DoctorSpecialization>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<DoctorSpecialization> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<DoctorSpecialization, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.DoctorSpecialization, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.DoctorSpecialization ConvertDbObjectToEntity(DoctorSpecialization dbObject)
		{
			return dbObject == null ? null : new Entities.DoctorSpecialization(dbObject.Id, dbObject.DoctorId,
				dbObject.SpecializationId, dbObject.YearsOfExperience);
		}
	}
}
