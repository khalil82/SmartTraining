using SmartTraining.Data.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTraining.Data.EntityFramework.Mappers
{
    public class CourseStudentsMapper : EntityTypeConfiguration<CourseStudent>
    {
        public CourseStudentsMapper()
        {
            // Primary Key
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            //Property(t => t.CourseId).IsRequired();
            HasRequired(cs => cs.Course).WithMany(c => c.CourseStudents).HasForeignKey(c => c.CourseId);
            HasRequired(cs => cs.Student).WithMany(c => c.CourseStudents).HasForeignKey(c => c.StudentId);

            // Table Name
            ToTable("CourseStudents", "dbo");
        }
    }
    
}
