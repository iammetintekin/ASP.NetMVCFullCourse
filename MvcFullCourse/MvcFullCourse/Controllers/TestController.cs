using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFullCourse.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            ViewBag.MyName = "METİN TEKİN";
            List<string> Names = new List<string>();
            Names.Add("Ayşe");
            Names.Add("Merve");
            Names.Add("Sıla");
            ViewBag.Names = Names;
            return View();
        }
    }
}