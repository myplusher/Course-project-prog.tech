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

        public static List<Item> GetItems() {

            List<Item> itemList = new List<Item>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.item_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    itemList.Add(new Item() {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Rate = (int)reader["itemrate"],
                        SellerId = (int)reader["seller_id"],
                        Seller = (string)reader ["seller"],
                        Count = (int)reader["count"]
                    });
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

        public static Item GetItem(int Id) {
            Item item = new Item();
            using (var reader = (new MySqlCommand("SELECT * FROM `item_view` WHERE id = " + Id, connection)).ExecuteReader()) {
                while (reader.Read())
                    item = (new Item() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["name"],
                        Rate = (int)reader ["itemrate"],
                        SellerId = (int)reader ["seller_id"],
                        Seller = (string)reader ["seller"],
                        Count = (int)reader ["count"]
                    });
            }
            return item;
        }

        public static bool DeleteItem(int Id) {
            try {
                (new MySqlCommand("DELETE FROM `item` WHERE id = " + Id, connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Logger.InitLogger();
                Logger.Log.Info("Ошибка удаления товара. Причина: " + e);
                return false;
            }
        }

    }
}