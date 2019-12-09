using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Seller {

        private int id;
        private string name;
        private int rate;
        private string place;


        public int Id { get; set; }
        [DisplayName("Организация")]
        public string Name { get; set; }
        [DisplayName("Рейтинг")]
        public int Rate { get; set; }
        [DisplayName("Местоположение")]
        public string Place { get; set; }
        

    }
}