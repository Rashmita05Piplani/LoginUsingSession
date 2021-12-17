using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginFormMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {   if (Session["username"] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}