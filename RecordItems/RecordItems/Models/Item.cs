using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Item {

        private int id;
        private string name;
        private int seller;
        private int rate;
        private int count;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Seller { get; set; }
        public int Rate { get; set; }
        public int Count { get; set; }

    }
}