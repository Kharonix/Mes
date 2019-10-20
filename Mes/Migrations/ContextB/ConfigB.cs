namespace Mes.Migrations.ContextB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigB : DbMigrationsConfiguration<Mes.Models.ApplicationDbContext>
    {
        public ConfigB()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContextB";
            ContextKey = "Mes.Models.ApplicationDbContext";
        }

        protected override void Seed(Mes.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
