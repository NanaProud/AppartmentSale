using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // MUST go first.

            modelBuilder.HasDefaultSchema("SYSTEM"); // Use uppercase!

            modelBuilder.Entity<Owning>()
                        .HasKey(x => new { x.OwnerId, x.AppartmentId });
            modelBuilder.Entity<Owning>()
                        .HasRequired(t => t.Owner)
                        .WithMany(t => t.Appartments)
                        .HasForeignKey(t => t.OwnerId);
            modelBuilder.Entity<Owning>()
                      .HasRequired(t => t.Appartment)
                      .WithMany(t => t.Owners)
                      .HasForeignKey(t => t.AppartmentId);
        }
    }
}
