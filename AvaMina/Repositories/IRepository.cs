using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public interface IRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity Get(int id);
        TEntity Find(int id);
        void AddRange(IEnumerable<TEntity> entities);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void SaveAsync();
    }
}
