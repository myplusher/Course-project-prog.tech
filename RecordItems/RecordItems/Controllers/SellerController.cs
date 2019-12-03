using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

namespace RecordItems.Controllers {
    public class SellerController : Controller {

        DAOSeller daoSeller = new DAOSeller();

        // GET: Seller
        public ActionResult Index() {
            return View(daoSeller.GetSellers());
        }
    }
}