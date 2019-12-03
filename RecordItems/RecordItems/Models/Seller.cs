using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Seller {

        private int id;
        private string name;
        private int rate;
        private string place;


        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Place { get; set; }

    }
}