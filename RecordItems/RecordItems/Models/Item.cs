using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Название")]
        public string Name { get; set; }
        public int SellerId { get; set; }
        [DisplayName("Поставщик")]
        public string Seller { get; set; }
        [DisplayName("Рейтинг")]
        public int Rate { get; set; }
        [DisplayName("В количестве")]
        public int Count { get; set; }

    }
}