using SmartTraining.Business.Handlers.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartTraining.API.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentHandler _studentHandler;

        public StudentsController(IStudentHandler studentHandler)
        {
            _studentHandler = studentHandler;
        }
        public ActionResult Student(int id)
        {
            var course = _studentHandler.GetStudentById(id);
            return View(course);
        }

        public ActionResult All()
        {
            var allStudents = _studentHandler.GetAll();
            return View(allStudents);
        }


    }
}