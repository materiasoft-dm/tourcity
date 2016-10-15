using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TourCity.Common.Entities;
using TourCity.Repository;
using TourCity.Repository.Repositories;
using TourCity.Web.Models;

namespace TourCity.Web.Controllers
{
    public class SpaceController : Controller
    {
        SpaceRepository _repo = null;
        public SpaceController()
        {
            this._repo = new SpaceRepository(new TourCityDbContext());
        }
        // GET: Business
        public PartialViewResult Welcome()
        {
            return PartialView();
        }

        public JsonResult GetBusiness(int id)
        {

            var entity = _repo.Retrieve(id);
            if (entity != null)
            {
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public HttpStatusCodeResult Create(Space space)
        {
            try
            {
                _repo.Create(space);
                _repo.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Format("message:{0} - inner:{1})", ex.Message, ex.InnerException?.Message));
                throw;
            }
        }

        public HttpStatusCodeResult UpdateProperty(string value, string propertyName, int id)
        {
            try
            {
                var entity = _repo.Retrieve(id);
               
                PropertyInfo propertyInfo = entity.GetType().GetProperty(propertyName);
                propertyInfo.SetValue(entity, Convert.ChangeType(value, propertyInfo.PropertyType), null);

                _repo.Update(entity);
                _repo.SaveChanges();
                
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Format("message:{0} - inner:{1})", ex.Message, ex.InnerException?.Message));
                throw;
            }
        }

    }
}