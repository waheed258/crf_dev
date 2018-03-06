using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMUI.Controllers
{
    public class ClientRegController : Controller
    {
        //
        // GET: /ClientReg/
        public ActionResult ClientReg()
        {
            return View();
        }
        public ActionResult AllClients()
        {
            return View();
        }
	}
}