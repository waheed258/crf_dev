using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMUI.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult UsersList()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }


	}
}