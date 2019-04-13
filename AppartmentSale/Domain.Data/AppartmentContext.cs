using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Domain.Data
{
    public class AppartmentContext : DbContext
    {
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Owning> Ownings { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<TypeDocument> TypeDocuments { get; set; }

        public AppartmentContext() : base("OracleDbContext") { }
    }
}
