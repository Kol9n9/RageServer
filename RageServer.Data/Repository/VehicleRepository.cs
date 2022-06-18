using RageServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RageServer.Data.Repository
{
    public class VehicleRepository : IRepository<VehicleModel>
    {
        private ServerDbContext dbContext;
        public VehicleRepository()
        {
            dbContext = new ServerDbContext();
        }
        public void Add(VehicleModel entity)
        {
            dbContext.Vehicles.Add(entity);
            dbContext.SaveChanges();
        }

        public VehicleModel Get(Expression<Func<VehicleModel, bool>> predicate)
        {
            return dbContext.Vehicles.FirstOrDefault(predicate);
        }

        public IEnumerable<VehicleModel> GetAll()
        {
            return dbContext.Vehicles;
        }

        public IEnumerable<VehicleModel> GetAll(Expression<Func<VehicleModel, bool>> predicate)
        {
            return dbContext.Vehicles.Where(predicate);
        }

        public bool IsExist(Expression<Func<VehicleModel, bool>> predicate)
        {
            return dbContext.Vehicles.FirstOrDefault(predicate) != null;
        }

        public void Remove(VehicleModel entity)
        {
            dbContext.Vehicles.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(VehicleModel entity)
        {
            dbContext.Vehicles.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
