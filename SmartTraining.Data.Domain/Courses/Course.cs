using System;
using System.Collections.Generic;

namespace SmartTraining.Data.Domain.Courses
{
    public class Course : AuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
