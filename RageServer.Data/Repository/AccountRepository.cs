using RageServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RageServer.Data.Repository
{
    public class AccountRepository : IRepository<AccountModel>
    {
        private readonly ServerDbContext dbContext;
        public AccountRepository()
        {
            dbContext = new ServerDbContext();
        }
        public void Add(AccountModel entity)
        {
            dbContext.Accounts.Add(entity);
            dbContext.SaveChanges();
        }

        public AccountModel Get(Expression<Func<AccountModel, bool>> predicate)
        {
            return dbContext.Accounts.FirstOrDefault(predicate);
        }

        public IEnumerable<AccountModel> GetAll()
        {
            return dbContext.Accounts;
        }

        public IEnumerable<AccountModel> GetAll(Expression<Func<AccountModel, bool>> predicate)
        {
            return dbContext.Accounts.Where(predicate);
        }
        public bool IsExist(Expression<Func<AccountModel, bool>> predicate)
        {
            return dbContext.Accounts.FirstOrDefault(predicate) != null;
        }

        public void Remove(AccountModel entity)
        {
            dbContext.Accounts.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(AccountModel entity)
        {
            dbContext.Accounts.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
