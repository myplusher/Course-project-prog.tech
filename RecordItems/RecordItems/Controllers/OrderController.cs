using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

namespace RecordItems.Controllers {
    public class OrderController : Controller {

        DAOOrder daoOrder = new DAOOrder();

        public ActionResult Index() {
            return View(daoOrder.GetOrders());
        }


        public ActionResult Order() {

            return View(daoOrder.GetOrders());
        }
    }
}