using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormMvc.Models;

namespace LoginFormMvc.Controllers
{
    public class LoginController : Controller
    {
        LoginEntities db = new LoginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {   if (ModelState.IsValid == true)
            {
                var credentials = db.Users.Where(model => model.username == user.username && model.password == user.password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }


                else
                {
                    Session["username"] = user.username;
                    return RedirectToAction("Index", "Default");
                }
            }
            return View();
            

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
            
        }
    }
}