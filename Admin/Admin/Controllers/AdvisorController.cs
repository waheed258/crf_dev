using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class AdvisorController : Controller
    {
        //
        // GET: /Advisor/
        public ActionResult NewAdvisor()
        {
            return View();
        }

        public ActionResult AdvisorList()
        {
            return View();
        }
	}
}