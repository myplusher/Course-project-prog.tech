using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

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
    }
}