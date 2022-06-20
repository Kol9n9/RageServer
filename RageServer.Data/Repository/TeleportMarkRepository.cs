using RageServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace RageServer.Data.Repository
{
    public class TeleportMarkRepository : IRepository<TeleportMarkModel>
    {
        private ServerDbContext dbContext;
        public TeleportMarkRepository()
        {
            dbContext = new ServerDbContext();
        }
        public void Add(TeleportMarkModel entity)
        {
            dbContext.TeleportMarks.Add(entity);
            dbContext.SaveChanges();
        }

        public TeleportMarkModel Get(Expression<Func<TeleportMarkModel, bool>> predicate)
        {
            return dbContext.TeleportMarks.FirstOrDefault(predicate);
        }

        public IEnumerable<TeleportMarkModel> GetAll()
        {
            return dbContext.TeleportMarks;
        }

        public IEnumerable<TeleportMarkModel> GetAll(Expression<Func<TeleportMarkModel, bool>> predicate)
        {
            return dbContext.TeleportMarks.Where(predicate);
        }

        public bool IsExist(Expression<Func<TeleportMarkModel, bool>> predicate)
        {
            return dbContext.TeleportMarks.FirstOrDefault(predicate) != null;
        }

        public void Remove(TeleportMarkModel entity)
        {
            dbContext.TeleportMarks.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(TeleportMarkModel entity)
        {
            dbContext.TeleportMarks.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
