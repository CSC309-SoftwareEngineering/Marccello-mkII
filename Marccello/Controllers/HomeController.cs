using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marccello.Models;
namespace Marccello.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            MajorModel b = new MajorModel();
            IEnumerable<SelectListItem> items = b.Maj().Select(c => new SelectListItem
            {
                Text = c.department,
                Value = c.department.ToString()

            });
            ViewBag.department = items;
            return View();
        }

    }
}
