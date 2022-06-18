using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>()
                .Property(x => x.SpawnPosition)
                .HasConversion(new ValueConverter<System.Numerics.Vector3, string>(
                    v => JsonConvert.SerializeObject(v), // Convert to string for persistence
                    v => JsonConvert.DeserializeObject<System.Numerics.Vector3>(v) // Convert to List<String> for use
                 ));
        }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<SocialAccountModel> SocialAccounts { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
    }   
}
