using System;
using System.Collections.Generic;
using SmartTraining.Data.Domain.Courses;

namespace SmartTraining.Data.Domain.Students
{
    public class Student : AuditedEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}