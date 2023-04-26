using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lec9.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

    }
}
