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
        public static StudentDto StudentToStudentDto(Student student)
        {
            if (student == null) return null;
            var dto = new StudentDto
            {
                Id = student.Id,
                BirthDate = student.BirthDate,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Email = student.Email
            };
            return dto;
        }
    }
}
