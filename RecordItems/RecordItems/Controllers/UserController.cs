using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers {
    public class UserController : Controller {

        DAOUser daoUser = new DAOUser();

        // GET: User
        [Authorize]
        public ActionResult Index() {
            return View(DAOUser.GetUsers());
        }

        [Authorize]
        public ActionResult Create() {
            ViewBag.Message = DAOUser.GetUsers();
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] User du) {
            try {
                if (DAOUser.InsertUsAdd(du))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index");
            }
            catch {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Details(int id) {
            return View(DAOUser.GetUser(id));
        }

        [Authorize]
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