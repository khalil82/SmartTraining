using SmartTraining.Business.DTO.Courses;
using SmartTraining.Data.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTraining.Business.Mappers
{
    public class CourseMapper
    {

        public static CourseDto CourseToCourseDto(Course poco)
        {
            if (poco == null) return null;
            var dto = new CourseDto
            {
                Name = poco.Name,
                Hours = poco.Hours,
                StartDate = poco.StartDate,
                EndDate = poco.EndDate,
                Id = poco.Id
            };
            return dto;

        }

        public static Course CourseDtoToCourse(Course dto)
        {
            if (dto == null) return null;
            var poco = new Course
            {
                Name = dto.Name,
                Hours = dto.Hours,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Id = dto.Id
            };
            return poco;

        }

    }
}
