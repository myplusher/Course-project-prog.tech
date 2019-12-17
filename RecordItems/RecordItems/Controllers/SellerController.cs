using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Controllers {
    public class SellerController : Controller {

        DAOSeller daoSeller = new DAOSeller();

        // GET: Seller
        [Authorize]
        public ActionResult Index() {
            return View(DAOSeller.GetSellers());
        }

        [Authorize]
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

        [Authorize]
        public ActionResult Delete( int id) {
            return View(DAOSeller.GetSeller(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (ModelState.IsValid && DAOSeller.DeleteSeller(id))
                return RedirectToAction("Index");
            return View();
        }

        [Authorize]
        public ActionResult Details(int id) {
            return View(DAOSeller.GetSeller(id));
        }

        [Authorize]
        public ActionResult Edit(int id) {
            return View(DAOSeller.GetSeller(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, Place, Rate")]Seller seller) {
            if (ModelState.IsValid && DAOSeller.EditSeller(seller))
                return RedirectToAction("Index");
            return View();
        }


    }
}