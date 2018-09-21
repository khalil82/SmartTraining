
using System.Web.Mvc;
using SmartTraining.Business.DTO.Courses;
using SmartTraining.Business.Handlers.Course;

namespace SmartTraining.API.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseHandler _courseHandler;

        public CoursesController(ICourseHandler courseHandler)
        {
            _courseHandler = courseHandler;
        }
        // GET: Courses
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[System.Web.Mvc.Route("{controller}/GetCourse/{id}")]
        public ActionResult Course(int id)
        {
            var course = _courseHandler.GetCourseById(id);
            return View(course);
        }

        public ActionResult All()
        {
            var allCourses = _courseHandler.GetAll();
            return View(allCourses);
        }

        public ActionResult CourseStudents(int id)
        {
            var students = _courseHandler.GetCourseStudents(id);
            return View(students);
        }

        [HttpPost]
        public ActionResult Edit(CourseDto courseDto)
        {
                //if (ModelState.IsValid)
                //{

                    var result = _courseHandler.EditCourse(courseDto);
                    return RedirectToAction("All");
                //}
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _courseHandler.GetCourseById(id);
            return View(course);
        }

        
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CourseDto courseDto)
        {
                //if (ModelState.IsValid)
                //{

                    var result = _courseHandler.Create(courseDto);
                    return RedirectToAction("All");
                //}
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            _courseHandler.Delete(id);
            return RedirectToAction("All");
        }
    }
}