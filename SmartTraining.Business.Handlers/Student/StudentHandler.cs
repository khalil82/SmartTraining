using System;
using System.Collections.Generic;
using System.Linq;
using SmartTraining.Business.DTO.Courses;
using SmartTraining.Business.DTO.Students;
using SmartTraining.Business.Mappers;
using SmartTraining.Data.Interfaces;

namespace SmartTraining.Business.Handlers.Student
{
    public class StudentHandler : IStudentHandler
    {
        private readonly IRepository<Data.Domain.Students.Student> _studentRepository;
        private readonly IRepository<Data.Domain.Courses.CourseStudent> _courseStudentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentHandler(IRepository<Data.Domain.Students.Student> studentRepository,
            IRepository<Data.Domain.Courses.CourseStudent> courseStudentRepository,
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _courseStudentRepository = courseStudentRepository;
            _unitOfWork = unitOfWork;
        }

        public StudentDto GetStudentById(int id)
        {
            var student = _studentRepository.Find(id);
            var result = StudentMapper.StudentToStudentDto(student);
            return result;
        }

        public List<CourseDto> GetCourseStudents(int id)
        {
            var student = _studentRepository.Find(id);
            var courses = _courseStudentRepository.FindByIncluding(t => t.StudentId == student.Id, t => t.Course);

            var result = courses.Select(cs => CourseMapper.CourseToCourseDto(cs.Course)).ToList();
            return result;
        }

        public List<StudentDto> GetAll()
        {
            var students = _studentRepository.FindBy(c => c.IsDeleted == false);
            var result = students.Select(c => StudentMapper.StudentToStudentDto(c)).ToList();
            return result;
        }

        public bool EditStudent(StudentDto studentDto)
        {
            var student = _studentRepository.FindBy(c => c.Id == studentDto.Id).FirstOrDefault();
            if (student != null)
            {
                student.FirstName = studentDto.FirstName;
                student.LastName = studentDto.LastName;

                student.Email = studentDto.Email;
                student.BirthDate = studentDto.BirthDate;
                
                _studentRepository.Update(student);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Create(StudentDto studentDto)
        {
            try
            {
                var student = new Data.Domain.Students.Student
                {
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CreatedBy = "Khalil",
                    ModifiedBy = "Khalil",
                    IsDeleted = false,
                    FirstName = studentDto.FirstName,
                    LastName = studentDto.LastName,
                    Email = studentDto.Email,
                    BirthDate = studentDto.BirthDate,
                };
                _studentRepository.Add(student);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //CsLog.LogException(e);
                throw e;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var student = _studentRepository.GetSingle(c => c.Id == id);
                if (student == null) return false;
                student.IsDeleted = true;
                _studentRepository.Update(student);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //CsLog.LogException(ex);
                throw ex;
            }

        }

    }
}
