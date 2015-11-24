namespace StudentSystem.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Students.AddOrUpdate(
                new Student()
                {
                    FirstName = "Andrew",
                    LastName = "Peters",
                },
                new Student()
                {
                    FirstName = "Brice",
                    LastName = "Lambson"
                },
                new Student()
                {
                    FirstName = "Rowan",
                    LastName = "Miller"
                });

            context.Courses.AddOrUpdate(
                new Course()
                {
                    Name = "Web Services and Cloud",
                    Description = "Heavy server logic building + introduction to cloud based services."
                });
        }
    }
}
