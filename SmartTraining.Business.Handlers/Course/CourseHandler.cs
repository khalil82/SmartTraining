using System;
using System.Collections.Generic;
using System.Linq;
using SmartTraining.Business.DTO.Courses;
using SmartTraining.Business.DTO.Students;
using SmartTraining.Business.Mappers;
using SmartTraining.Data.Interfaces;


namespace SmartTraining.Business.Handlers.Course
{
    public class CourseHandler : ICourseHandler
    {
        private readonly IRepository<Data.Domain.Courses.Course> _courseRepository;
        private readonly IRepository<Data.Domain.Courses.CourseStudent> _courseStudentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseHandler(IRepository<Data.Domain.Courses.Course> courseRepository,
            IUnitOfWork unitOfWork, IRepository<Data.Domain.Courses.CourseStudent> courseStudentRepository)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _courseStudentRepository = courseStudentRepository;

        }

        public CourseDto GetCourseById(int id)
        {
            var course = _courseRepository.Find(id);
            var result = CoursesMapper.CourseToCourseDto(course);
            return result;
        }

        public List<StudentDto> GetCourseStudents(int id)
        {
            var course = _courseRepository.Find(id);
            var students = _courseStudentRepository.FindByIncluding(t => t.CourseId == course.Id, t => t.Student);
            var result = new List<StudentDto>();
            foreach (var cs in students)
            {
                var dto = StudentMapper.StudentToStudentDto(cs.Student);
                result.Add(dto);
            }

            return result;
        }

        public List<CourseDto> GetAll()
        {
            var result = new List<CourseDto>();
            //var courses = _courseRepository.GetAll();
            var courses = _courseRepository.FindBy(c => c.IsDeleted == false);
            foreach (var c in courses)
            {
                var dto = CoursesMapper.CourseToCourseDto(c);
                result.Add(dto);
            }

            return result;
        }

        public bool EditCourse(CourseDto coursesDto)
        {
            Data.Domain.Courses.Course course = _courseRepository.FindBy(c => c.Id == coursesDto.Id).FirstOrDefault();
                if (course != null)
                {
                course.Name = coursesDto.Name;
                course.StartDate = coursesDto.StartDate;
                course.EndDate = coursesDto.EndDate;
                course.Hours = coursesDto.Hours;
                _courseRepository.Update(course);
                _unitOfWork.SaveChanges();
                return true;
                }
                return false;
        }


        public bool Create(CourseDto courseDto)
        {
            try
            {
                Data.Domain.Courses.Course course = new Data.Domain.Courses.Course
                {
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    CreatedBy = "Khalil",
                    ModifiedBy = "Khalil",
                    IsDeleted = false,
                    Name = courseDto.Name,
                    Hours = courseDto.Hours,
                    StartDate = courseDto.StartDate,
                    EndDate = courseDto.EndDate
                };
                _courseRepository.Add(course);
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
                Data.Domain.Courses.Course course = _courseRepository.GetSingle(c => c.Id == id);
                if (course == null) return false;
                course.IsDeleted = true;
                _courseRepository.Update(course);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //CsLog.LogException(ex);
                throw ex;
                return false;
            }

        }

    }

   
}
