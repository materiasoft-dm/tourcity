﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourCity.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Home
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult Categories()
        {
            return PartialView();
        }
    }
}