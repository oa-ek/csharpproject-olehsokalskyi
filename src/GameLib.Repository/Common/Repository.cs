﻿using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        protected ProjectContext _ctx;
        //protected DbSet<TEntity> dbSet;

        public Repository(ProjectContext ctx)
        {
            _ctx = ctx;
            //dbSet = _ctx.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _ctx.Set<TEntity>().ToListAsync();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _ctx.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _ctx.Set<TEntity>().Update(entity);
            await SaveAsync();
        }
        public virtual async Task DeleteAsync(TKey id)
        {
            _ctx.Set<TEntity>().Remove(await _ctx.Set<TEntity>().FindAsync(id));
            await SaveAsync();

        }
        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveAsync() => await _ctx.SaveChangesAsync();
    }
}
