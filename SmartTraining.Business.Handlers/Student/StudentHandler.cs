using SmartTraining.Data.Interfaces;

namespace SmartTraining.Business.Handlers.Student
{
    public class StudentHandler : IStudentHandler
    {
        private readonly IRepository<Data.Domain.Students.Student> _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentHandler(IRepository<Data.Domain.Students.Student> studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

    }
}
