using lec10.Models;
using Microsoft.AspNetCore.Mvc;

namespace lec10.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository studentRepository;

        public StudentController() { 
            studentRepository = new StudentRepository();
        }

      
        [HttpGet("id")]
        public IActionResult GetSingle(int id)
        {
            Console.WriteLine(id);
            Console.WriteLine("---------------------------------------------------");
            Student student = studentRepository.GetStudent(id);

            return View(student);
        }


        public IActionResult Index()
        {
            // Controller to View ways :
            // as a model
            // view bag
            // view data
            // temo data

            Student student = studentRepository.GetStudent(1);

            // viewbag
            string s = "some data by controller for ViewBag";
            ViewBag.abc = s;

            // tempdata
            ViewData["x"] = "some data by controller for ViewData";

            // tempdata
            TempData["x"] = "some data by controller for TempData";

            return View(student);
        }

        public IActionResult AllStudents()
        {
            return View(studentRepository.GetAllStudent());
        }
        

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string name, string semester)
        {
            Console.WriteLine(name);
            Console.WriteLine("======================");
            Console.WriteLine(semester);

            return View();
        }

       


    }
}
