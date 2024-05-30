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
	public class specializationDal : BaseDal<DefaultDbContext, Specialization, Entities.Specialization, int, specializationSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public specializationDal()
		{
		}

		protected internal specializationDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Specialization entity, Specialization dbObject, bool exists)
		{
			dbObject.SpecializationName = entity.SpecializationName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Specialization>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Specialization> dbObjects, specializationSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Specialization>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Specialization> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Specialization, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Specialization, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Specialization ConvertDbObjectToEntity(Specialization dbObject)
		{
			return dbObject == null ? null : new Entities.Specialization(dbObject.Id, dbObject.SpecializationName);
		}
	}
}
