using System.Collections.Generic;
using System.Linq;
using licenseItExternal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace licenseItExternal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _context;

        private readonly DbSet<TEntity> _dbSet;

        protected Repository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
        }
        
        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public virtual bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public virtual bool Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

    }
}
