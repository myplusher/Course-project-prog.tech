using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RecordItems.DAO {
    public class DAO {
        public MySqlConnection connection = new MySqlConnection("server = localhost; port=3306;username=root;password=root;database=database;");

        public MySqlConnection Connection { get; set; }

    }
}