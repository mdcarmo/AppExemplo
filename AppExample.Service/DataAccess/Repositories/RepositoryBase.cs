using AppExample.Service.DataAccess.Context;
using AppExample.Service.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AppExample.Service.DataAccess.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected AppExampleContext _dbContext = new AppExampleContext();
		IDbSet<TEntity> DbSet;

		public RepositoryBase()
		{
			DbSet = _dbContext.Set<TEntity>();
		}

		public void Add(TEntity obj)
		{
			_dbContext.Set<TEntity>().Add(obj);
			_dbContext.SaveChanges();
		}

		public TEntity GetById(Guid id)
		{
			return DbSet.Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return DbSet.ToList();
		}
		public virtual IEnumerable<TEntity> GetAllReadOnly()
		{
			return DbSet.AsNoTracking();
		}
		public void Update(TEntity obj)
		{
			var entry = _dbContext.Entry(obj);
			DbSet.Attach(obj);
			entry.State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public void Remove(TEntity obj)
		{
			DbSet.Remove(obj);
			_dbContext.SaveChanges();

		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate);
		}

		public void Dispose()
		{
			_dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
