using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourCity.Web.Controllers
{
    public class SpaceController : Controller
    {
        // GET: Business
        public PartialViewResult Welcome()
        {
            return PartialView();
        }
    }
}