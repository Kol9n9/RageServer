using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RageServer.Data.Models
{
    public class ServerDbContext : DbContext
    {
        private readonly string connectionString = "server=localhost;database=rage;user=root;password=123456";
        public ServerDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ob => ob.MigrationsAssembly(typeof(ServerDbContext).GetTypeInfo().Assembly.GetName().Name));
        }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<SocialAccountModel> SocialAccounts { get; set; }
    }   
}
