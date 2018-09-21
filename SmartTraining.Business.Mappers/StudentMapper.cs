using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTraining.Business.DTO.Students;
using SmartTraining.Data.Domain.Students;

namespace SmartTraining.Business.Mappers
{
    public class StudentMapper
    {
        public static StudentDto StudentToStudentDto(Student poco)
        {
            if (poco == null) return null;
            var dto = new StudentDto
            {
                Id = poco.Id,
                BirthDate = poco.BirthDate,
                LastName = poco.LastName,
                FirstName = poco.FirstName,
                Email = poco.Email
            };
            return dto;
        }

        public static Student StudentDtoToStudent(StudentDto dto)
        {
            if (dto == null) return null;
            var poco = new Student
            {
                Id = dto.Id,
                BirthDate = dto.BirthDate,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email
            };
            return poco;
        }

    }
}
