using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers {
    public class OrderController : Controller {

        DAOOrder daoOrder = new DAOOrder();

        public ActionResult Index() {
            return View(daoOrder.GetOrders());
        }


        public ActionResult Order() {
            return View();
        }

        public ActionResult Create() {
            ViewBag.Message = DAOUser.GetUsers();
            ViewBag.Item = DAOItem.GetItems();
            return View(new Order());
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Order dor) {
            try {
                if (daoOrder.InsertOrder(dor))
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