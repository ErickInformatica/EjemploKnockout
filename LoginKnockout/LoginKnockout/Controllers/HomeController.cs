using LoginKnockout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginKnockout.Controllers
{
    public class HomeController : Controller
    {
        private EntityKnockout db = new EntityKnockout();

        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }



        public ActionResult Usuario()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLogIn objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Usuario.Where(a => a.Correo.Equals(objUser.Correo) && a.Pass.Equals(objUser.Password)).FirstOrDefault();

                if (obj != null)
                {
                    System.Diagnostics.Debug.WriteLine("Estoy en Usuario");
                    Session["UserID"] = obj.UsuarioId.ToString();
                    Session["Correo"] = obj.Correo.ToString();
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return View(objUser);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
