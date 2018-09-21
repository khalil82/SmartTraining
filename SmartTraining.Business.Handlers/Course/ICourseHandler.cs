using System.Collections.Generic;
using SmartTraining.Business.DTO.Courses;
using SmartTraining.Business.DTO.Students;

namespace SmartTraining.Business.Handlers.Course
{
    public interface ICourseHandler
    {
        CourseDto GetCourseById(int id);
        List<StudentDto> GetCourseStudents(int id);
        List<CourseDto> GetAll();
        bool EditCourse(CourseDto coursesDto);
        bool Create(CourseDto courseDto);
        bool Delete(int id);
    }
}