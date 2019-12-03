using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Order {

        private int id;
        private string user;
        private string item;
        private int count;
        private DateTime date;

        public int Id { get; set; }
        public string User { get; set; }
        public string Item { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

    }
}