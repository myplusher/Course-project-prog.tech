using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class Supply {
        public int Id { get; set; }
        [DisplayName("id поставки")]
        public int SellerId { get; set; }
        [DisplayName("Поставщик")]
        public string SellerText { get; set; }
        [DisplayName("id товара")]
        public int ItemId { get; set; }
        [DisplayName("Товар")]
        public string ItemText { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}