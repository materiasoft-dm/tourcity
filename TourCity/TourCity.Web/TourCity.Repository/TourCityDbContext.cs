using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using TourCity.Common.Entities;
using TourCity.Repository;

namespace TourCity.Repository
{
    public class TourCityDbContext : DbContext
    {
        public TourCityDbContext() : base("TourCityConnection")
        {
           
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Space> Spaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<TourCityDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }



    }

}

