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
	public class doctorDal : BaseDal<DefaultDbContext, Doctor, Entities.Doctor, int, doctorSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public doctorDal()
		{
		}

		protected internal doctorDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Doctor entity, Doctor dbObject, bool exists)
		{
			dbObject.LastName = entity.LastName;
			dbObject.FirstName = entity.FirstName;
			dbObject.MiddleName = entity.MiddleName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.Gender = entity.Gender;
			dbObject.Education = entity.Education;
			dbObject.PhoneNumber = entity.PhoneNumber;
			dbObject.EmailAddress = entity.EmailAddress;
			dbObject.IsDeleted = entity.IsDeleted;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Doctor>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Doctor> dbObjects, doctorSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Doctor>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Doctor> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Doctor, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Doctor, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Doctor ConvertDbObjectToEntity(Doctor dbObject)
		{
			return dbObject == null ? null : new Entities.Doctor(dbObject.Id, dbObject.LastName, dbObject.FirstName,
				dbObject.MiddleName, dbObject.DateOfBirth, dbObject.Gender, dbObject.Education, dbObject.PhoneNumber,
				dbObject.EmailAddress, dbObject.IsDeleted);
		}
	}
}
