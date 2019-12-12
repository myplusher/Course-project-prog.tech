using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Покупатель")]
        public string User { get; set; }
        [DisplayName("Товар")]
        public string Item { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Дата заказа")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

    }
}