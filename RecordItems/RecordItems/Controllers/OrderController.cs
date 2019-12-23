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

        [Authorize]
        public ActionResult Index() {
            return View(daoOrder.GetOrders());
        }

        [Authorize]
        public ActionResult IndexCustom() {
            return View(daoOrder.GetOrders());
        }

        [Authorize]
        public ActionResult Order() {
            return View();
        }
        [Authorize]
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

        [Authorize]
        public ActionResult CreateCustom() {
            ViewBag.Message = DAOUser.GetUsers();
            ViewBag.Item = DAOItem.GetItems();
            return View(new Order());
        }

        [HttpPost]
        public ActionResult CreateCustom([Bind(Exclude = "Id")] Order dor) {
            try {
                if (daoOrder.InsertOrder(dor))
                    return RedirectToAction("IndexCustom");
                else
                    return RedirectToAction("IndexCustom");
            }
            catch {
                return RedirectToAction("IndexCustom");
            }
        }

        [Authorize]
        public ActionResult Details(int id) {
            return View(daoOrder.GetOrder(id));
        }

        [Authorize]
        public ActionResult DetailsCustom(int id) {
            return View(daoOrder.GetOrder(id));
        }

    }
}