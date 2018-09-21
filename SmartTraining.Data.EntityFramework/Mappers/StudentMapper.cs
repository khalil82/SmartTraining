using System;
using System.Data.Entity.ModelConfiguration;
using SmartTraining.Data.Domain.Students;

namespace SmartTraining.Data.EntityFramework.Mappers
{
    public class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
                // Primary Key
                HasKey(t => t.Id);
                Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

                // Properties
                Property(t => t.FirstName).IsRequired();
                Property(t => t.LastName).IsRequired();
                Property(t => t.Email).IsRequired();
                Property(t => t.BirthDate).IsRequired();

                // Auditing Properties
                Property(t => t.CreatedBy).IsRequired();
                Property(t => t.CreatedAt).IsRequired();
                Property(t => t.ModifiedBy).IsRequired();
                Property(t => t.ModifiedAt).IsRequired();
                Property(t => t.IsDeleted).IsRequired();

                // Table Name
                ToTable("Student", "dbo");
        }
    }
}
