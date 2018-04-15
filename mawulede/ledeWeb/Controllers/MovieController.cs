using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ledeWeb.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Id = 0;
            }
            else
            {
                ViewBag.Id = id.Value;
            }
            return View();
        }
    }
}