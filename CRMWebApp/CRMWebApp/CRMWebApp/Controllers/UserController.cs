﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMWebApp.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ViewResult CreateUser()
        {
            return View();
        }
	}
}