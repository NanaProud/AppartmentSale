using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Domain.Data.Models;
namespace Domain.Data
{
    public class AppartmentContext : DbContext
    {
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Area> Areas { get; set; }
        //public Db

        public AppartmentContext() : base("OracleDbContext")
        {
            Database.Exists();
        }
    }
}
