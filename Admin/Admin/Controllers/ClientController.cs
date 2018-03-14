using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        public ActionResult ClientsList()
        {
            return View();
        }
	}
}