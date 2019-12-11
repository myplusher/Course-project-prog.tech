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
        public ActionResult Index()
        {
            return View(daoItem.GetItems());
        }

        public ActionResult Item() {
            return View();
        }

        public ActionResult Create() {
            ViewBag.Message = DAOSeller.GetSellers();
            return View(new Item());
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
    }
}