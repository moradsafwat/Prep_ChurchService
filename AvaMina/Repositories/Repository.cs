using AvaMina.Data;
using AvaMina.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext db;
        public Repository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);

            SaveAsync();
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            SaveAsync();
        }


        public TEntity Find(int id)
        {
           var entity = db.Set<TEntity>().Find(id);
           return entity;
        }

        public IList<TEntity> List()
        {
           return db.Set<TEntity>().ToList();
        }

        public void Update(int id, TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            SaveAsync();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            SaveAsync();
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRangeAsync(entities);
            
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveAsync()
        {
            db.SaveChanges();
        }

        
    }
}
