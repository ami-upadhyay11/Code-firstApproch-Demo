namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirstDemo.Program.MyContext>
    {
        public Configuration()
        {
          //  AutomaticMigrationsEnabled = true;
          // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFCodeFirstDemo.Program.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
