using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RecordItems.Models {
    public class User {

        private int id;
        private string name;
        private string password;

        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }

    }
}