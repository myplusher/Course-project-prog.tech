using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

namespace RecordItems.Controllers {
    public class HomeController : Controller {

        [Authorize]
        public ActionResult Index() {
            if(User.Identity.IsAuthenticated) {
                ViewBag.Message = User.Identity.Name;
            }
            return View();
            
        }

        [Authorize]
        public ActionResult IndexCustom() {
            if (User.Identity.IsAuthenticated) {
                ViewBag.Message = User.Identity.Name;
            }
            return View();

        }

        [Authorize]
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}