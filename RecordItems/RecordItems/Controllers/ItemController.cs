using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers
{
    public class ItemController : Controller
    {
        DAOItem daoItem = new DAOItem();




        // GET: Item
        [Authorize]
        public ActionResult Index()
        {
            return View(DAOItem.GetItems());
        }

        [Authorize]
        public ActionResult Item() {
            return View();
        }

        [Authorize]
        public ActionResult Create() {
            ViewBag.Message = DAOSeller.GetSellers();
            return View(new Item());
        }

        [Authorize]
        public ActionResult Details(int id) {
            return View(DAOItem.GetItem(id));
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Item di) {
            try {
                if (daoItem.InsertItem(di))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index");
            }
            catch {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Delete(int id) {
            return View(DAOItem.GetItem(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (ModelState.IsValid && DAOItem.DeleteItem(id))
                return RedirectToAction("Index");
            return View();
        }
    }
}