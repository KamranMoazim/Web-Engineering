
using Microsoft.AspNetCore.Mvc;

namespace lec172.Components
{
    public class CourseSummary : ViewComponent
    {
        // we have three methods to create ViewComponent
        // 1. Inheriting
        // 2. 
        // 3. 

        // way to use ViewComponent
        // 1. Tag-Helper
        // 2. 

        // public string InvokeAsync() // in case of async
        // public string Invoke()
        // {
        //     var data = "this is some courses data";
        //     return data;
        // }
        public IViewComponentResult Invoke()
        {
            string data = "this is some courses data";
            return View("Default", data);
        }
    }
}