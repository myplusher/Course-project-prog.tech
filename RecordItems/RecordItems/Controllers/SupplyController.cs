using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers
{
    public class SupplyController : Controller {
        // GET: Supply
        public ActionResult Index() {
            return View(DAOSupply.GetSupplies());
        }

        [Authorize]
        public ActionResult Details(int id) {
            return View(DAOSupply.GetSupply(id));
        }

        [Authorize]
        public ActionResult Create() {
            ViewBag.Message = DAOSeller.GetSellers();
            ViewBag.Item = DAOItem.GetItems();
            return View(new Supply());
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Supply ds) {
            try {
                if (DAOSupply.InsertSupply(ds))
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