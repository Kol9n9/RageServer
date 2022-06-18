using RageServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace RageServer.Data.Repository
{
    public class SocialAccountRepository : IRepository<SocialAccountModel>
    {
        private readonly ServerDbContext dbContext;
        public SocialAccountRepository()
        {
            dbContext = new ServerDbContext();
        }
        public void Add(SocialAccountModel entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public SocialAccountModel Get(Expression<Func<SocialAccountModel, bool>> predicate)
        {
            return dbContext.SocialAccounts.FirstOrDefault(predicate);
        }

        public IEnumerable<SocialAccountModel> GetAll()
        {
            return dbContext.SocialAccounts;
        }

        public IEnumerable<SocialAccountModel> GetAll(Expression<Func<SocialAccountModel, bool>> predicate)
        {
            return dbContext.SocialAccounts.Where(predicate);
        }

        public bool IsExist(Expression<Func<SocialAccountModel, bool>> predicate)
        {
            return dbContext.SocialAccounts.FirstOrDefault(predicate) != null;
        }

        public void Remove(SocialAccountModel entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(SocialAccountModel entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
