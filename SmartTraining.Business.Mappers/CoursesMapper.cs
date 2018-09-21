using SmartTraining.Business.DTO.Courses;
using SmartTraining.Data.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTraining.Business.Mappers
{
    public class CoursesMapper
    {

        public static CourseDto CourseToCourseDto(Course course)
        {
            if (course == null) return null;
            var courseDto = new CourseDto
            {
                Name = course.Name,
                Hours = course.Hours,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Id = course.Id
            };
            return courseDto;

        }

    }
}
