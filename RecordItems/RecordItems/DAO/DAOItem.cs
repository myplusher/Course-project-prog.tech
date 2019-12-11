using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecordItems.Models;
using MySql.Data.MySqlClient;
using RecordItems.Logging;
using System.Diagnostics;

namespace RecordItems.DAO {
    public class DAOItem : DAO {

        public List<Item> GetItems() {

            List<Item> itemList = new List<Item>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.item_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    itemList.Add(new Item() { Id = (int)reader["id"], Name = (string)reader["name"], Rate = (int)reader["itemrate"], Seller = (string)reader ["seller"], Count = (int)reader["count"] });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка товаров");

            return itemList;
        }

        public bool InsertItem(Item i) {

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            try {
                (new MySqlCommand("INSERT INTO `database`.`item`(`itemname`, `itemrate`, `seller`, `count`) VALUES ('" + i.Name + "','" + i.Rate + "','" + i.Seller + "','" + i.Count + "');", connection))
                    .ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);

                return false;
            }
        }

    }
}