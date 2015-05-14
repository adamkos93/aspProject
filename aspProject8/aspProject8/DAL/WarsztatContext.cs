using aspProjekt8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace aspProjekt2.DAL
{
    public class WarsztatContext : DbContext
    {
        public WarsztatContext()
            : base("WarsztatContext")
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Klient> Klients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}