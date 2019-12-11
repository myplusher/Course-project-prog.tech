using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers {
    public class SellerController : Controller {

        DAOSeller daoSeller = new DAOSeller();

        // GET: Seller
        public ActionResult Index() {
            return View(DAOSeller.GetSellers());
        }

        public ActionResult Create() {
            return View(new Seller());
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Seller ds) {
            try {
                if (daoSeller.InsertSeller(ds))
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