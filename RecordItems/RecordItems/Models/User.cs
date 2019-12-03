using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class User {

        private int id;
        private string name;
        private string password;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}