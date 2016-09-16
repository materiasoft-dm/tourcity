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
using TourCity.Repository;

namespace TourCity.Repository
{
    public class TestContext : DbContext
    {
        public TestContext() : base("TestContext")
        {
           
        }

        public DbSet<TestType> TestTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<TestContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

    }

    public class TestType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

