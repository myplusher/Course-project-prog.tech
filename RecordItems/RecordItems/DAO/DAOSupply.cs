using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecordItems.Models;
using MySql.Data.MySqlClient;
using RecordItems.Logging;
using System.Diagnostics;

namespace RecordItems.DAO {
    public class DAOSupply : DAO {

        public static List<Supply> GetSupplies() {

            List<Supply> supplyList = new List<Supply>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.supply_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    supplyList.Add(new Supply() {
                        Id = (int)reader ["id"],
                        SellerId = (int)reader["id_seller"],
                        SellerText = (string)reader["seller"],
                        ItemId = (int)reader["id_item"],
                        ItemText = (string)reader["item"],
                        Count = (int)reader["count"]
                    });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка товаров");

            return supplyList;
        }

        public static bool InsertSupply(Supply i) {

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            try {
                (new MySqlCommand("INSERT INTO `database`.`supplies`(`seller`, `item`, `count`) VALUES ('" + i.SellerId + "','" + i.ItemId + "','" + i.Count + "');", connection))
                    .ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);

                return false;
            }
        }


        public static Supply GetSupply(int Id) {
            Supply supply = new Supply();
            using (var reader = (new MySqlCommand("SELECT * FROM `item_view` WHERE id = " + Id, connection)).ExecuteReader()) {
                while (reader.Read())
                    supply = (new Supply() {
                        Id = (int)reader ["id"],
                        SellerId = (int)reader ["id_seller"],
                        SellerText = (string)reader ["seller"],
                        ItemId = (int)reader ["id_item"],
                        ItemText = (string)reader ["item"],
                        Count = (int)reader ["count"]
                    });
            }
            return supply;
        }

        public static bool DeleteSupply(int Id) {
            try {
                (new MySqlCommand("DELETE FROM `supply` WHERE id = " + Id, connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Logger.InitLogger();
                Logger.Log.Info("Ошибка удаления поставки. Причина: " + e);
                return false;
            }
        }

    }
}