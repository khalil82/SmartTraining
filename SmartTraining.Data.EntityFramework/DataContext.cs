using System.Data.Entity;
using System.Linq;
using SmartTraining.Data.Domain.Courses;
using SmartTraining.Data.Domain.Students;
using SmartTraining.Data.EntityFramework.Mappers;

namespace SmartTraining.Data.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext() : base("SmartTrainingConnection")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMapper());
            modelBuilder.Configurations.Add(new CourseMapper());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entriesToReload = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();
            var rowCount = base.SaveChanges();

            if (rowCount > 0)
                entriesToReload.ForEach(e => e.Reload());

            return rowCount;

        }
    }
}

