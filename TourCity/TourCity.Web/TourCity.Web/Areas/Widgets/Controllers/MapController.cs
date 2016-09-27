using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourCity.Web.Areas.Widgets.Controllers
{
    public class MapController : Controller
    {
        // GET: Widgets/Map
        public PartialViewResult Pin(string longitude, string latitude)
        {
            ViewBag.ApiKey = ConfigurationManager.AppSettings["googleMapApiKey"];
            ViewBag.Lat = latitude;
            ViewBag.Lon = longitude;
            ViewBag.MapTitle = "";
            ViewBag.ZoomLevel = 15;

            return PartialView();
        }
    }
}