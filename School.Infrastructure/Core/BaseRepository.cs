using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.Domain.Repository;
using School.Infrastructure.Context;

namespace School.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SchoolContext context;
        private readonly DbSet<TEntity> myDbSet;
        public BaseRepository(SchoolContext context)
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();

        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbSet.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
            return this.myDbSet.ToList();
        }
        public virtual TEntity GetEntity(int id)
        {
            return this.myDbSet.Find(id);
        }
        public virtual void Remove(TEntity entity)
        {
            this.myDbSet.Remove(entity);
           

        }
        public virtual void Remove(TEntity[] entities)
        {
            this.myDbSet.RemoveRange(entities);
        }
        public virtual void Add(TEntity entity)
        {
            this.myDbSet.Add(entity);
        }
        public virtual void Add(TEntity[] entities)
        {
            this.myDbSet.AddRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }
        public virtual void Update(TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
