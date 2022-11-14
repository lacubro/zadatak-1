using zadatak1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zadatak1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(zadatak1.Models.Korisnik korisnikModel)
        {
            using(LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                var userDetails = db.Korisniks.Where(x => x.Username == korisnikModel.Username && x.Password == korisnikModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    korisnikModel.LoginErrorMessage = "Pogresno korisnicko ime ili lozinka !";
                    return View("Index", korisnikModel);
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["userName"] = userDetails.Username;
                    return RedirectToAction("Index", "Studentis");
                }
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}