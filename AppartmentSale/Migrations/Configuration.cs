using Domain.Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AppartmentSale.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<AppartmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppartmentContext appartmentContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
