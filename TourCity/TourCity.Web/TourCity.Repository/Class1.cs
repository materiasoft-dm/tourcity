using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using TourCity.Repository;

namespace TourCity.Repository
{
    public class TestContext : DbContext
    {
        public TestContext() : base("TestContext")
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<TestContext>(new SqliteCreateDatabaseIfNotExists<TestContext>(null));
        }

        public DbSet<TestType> TestTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names

        }

    }

    public class TestType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

