using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

namespace RecordItems.Controllers {
    public class UserController : Controller {

        DAOUser daoUser = new DAOUser();

        // GET: User
        public ActionResult Index() {
            return View(DAOUser.GetUsers());
        }

        public ActionResult Details(int id) {
            return View(DAOUser.GetUser(id));
        }

        public ActionResult Delete(int id) {
            return View(DAOUser.GetUser(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (ModelState.IsValid && DAOUser.DeleteUser(id))
                return RedirectToAction("Index");
            return View();
        }
    }
}