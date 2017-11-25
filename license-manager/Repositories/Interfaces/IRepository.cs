using System.Collections.Generic;

namespace licenseItExternal.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(object id);

        bool Insert(TEntity entity);

        bool Update(TEntity entityToUpdate);
        
        bool Delete(TEntity entityToUpdate);

    }
}
