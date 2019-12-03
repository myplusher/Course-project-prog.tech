﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordItems.DAO;

namespace RecordItems.Controllers {
    public class UserController : Controller {

        DAOUser daoUser = new DAOUser();

        // GET: User
        public ActionResult Index() {
            return View(daoUser.GetUsers());
        }
    }
}