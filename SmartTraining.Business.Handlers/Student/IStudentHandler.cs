using System.Collections.Generic;
using SmartTraining.Business.DTO.Courses;
using SmartTraining.Business.DTO.Students;

namespace SmartTraining.Business.Handlers.Student
{
    public interface IStudentHandler
    {
        StudentDto GetStudentById(int id);
        List<CourseDto> GetCourseStudents(int id);
        List<StudentDto> GetAll();
        bool EditStudent(StudentDto studentDto);
        bool Create(StudentDto studentDto);
        bool Delete(int id);
    }
}