using Enyapo.Core.Repository;
using Enyapo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(EnyapoDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public IQueryable<TEntity> JoinWhere(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
             return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> WhereMany(params Expression<Func<TEntity, bool>>[] predicates)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var item in predicates)
            {
                query = query.Where(item);
            }
            return query;
        }
    }
}
