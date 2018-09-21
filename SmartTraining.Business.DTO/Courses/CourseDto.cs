using System;

namespace SmartTraining.Business.DTO.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
