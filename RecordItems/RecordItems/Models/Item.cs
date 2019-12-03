using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Item {

        private int id;
        private string name;
        private string seller;
        private int rate;
        private int count;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Seller { get; set; }
        public int Rate { get; set; }
        public int Count { get; set; }

    }
}