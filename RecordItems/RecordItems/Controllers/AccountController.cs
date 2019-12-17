using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.Models;
using RecordItems.DAO;
using System.Web.Security;

namespace RecordItems.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model) {
            if (ModelState.IsValid) {
                User user = null;
                user = DAOUser.GetUserReg(model);

                if (user != null) {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u) {
            if (ModelState.IsValid) {
                User user = null;
                using (UserContext db = new UserContext()) {
                    user = DAOUser.GetUserReg(u);
                }
                if (user == null) {
                    DAOUser.InsertUsReg(u);

                    // если пользователь удачно добавлен в бд
                    if (user != null) {
                        FormsAuthentication.SetAuthCookie(u.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(u);
        }
        public ActionResult Logoff() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}