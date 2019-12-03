using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecordItems.Models;
using MySql.Data.MySqlClient;

namespace RecordItems.DAO {
    public class DAOItem : DAO {

        public List<Item> GetItems() {

            List<Item> itemList = new List<Item>();
            connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.item_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    itemList.Add(new Item() { Id = (int)reader["id"], Name = (string)reader["name"], Seller = (string)reader["seller"], Rate = (int)reader["itemrate"], Count = (int)reader["count"] });
                }
            }

            return itemList;
        }

    }
}