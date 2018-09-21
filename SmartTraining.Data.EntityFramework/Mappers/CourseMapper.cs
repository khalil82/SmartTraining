using System.Data.Entity.ModelConfiguration;
using SmartTraining.Data.Domain.Courses;

namespace SmartTraining.Data.EntityFramework.Mappers
{
    public class CourseMapper : EntityTypeConfiguration<Course>
    {
        public CourseMapper()
        {
            // Primary Key
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Name).IsRequired();
            Property(t => t.Hours).IsRequired();
            Property(t => t.StartDate).IsOptional();
            Property(t => t.EndDate).IsOptional();
            
            // Auditing Properties
            Property(t => t.CreatedBy).IsRequired();
            Property(t => t.CreatedAt).IsRequired();
            Property(t => t.ModifiedBy).IsRequired();
            Property(t => t.ModifiedAt).IsRequired();
            Property(t => t.IsDeleted).IsRequired();

            // Table Name
            ToTable("Course", "dbo");
        }
    }
}
