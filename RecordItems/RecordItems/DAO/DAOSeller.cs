using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;
using System.Diagnostics;

namespace RecordItems.DAO {
    public class DAOSeller : DAO {

        public static List<Seller> GetSellers() {

            List<Seller> sellerList = new List<Seller>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM seller;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    sellerList.Add(new Seller() { Id = (int)reader["id"], Name = (string)reader["sellername"], Place = (string)reader["sellerplace"], Rate = (int)reader["sellerrate"] });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка поставщиков");

            return sellerList;
        }

        public bool InsertSeller(Seller s) {

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            try {
                (new MySqlCommand("INSERT INTO `database`.`seller`(`sellername`, `sellerplace`, `sellerrate`) VALUES ('" + s.Name + "','" + s.Place + "','" + s.Rate + "');", connection))
                    .ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);

                return false;
            }
        }

        public static Seller GetSeller(int Id) {
            Seller seller = new Seller();
            using (var reader = (new MySqlCommand("SELECT * FROM `seller` WHERE id = " + Id, connection)).ExecuteReader()) {
                while (reader.Read())
                    seller = (new Seller() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["sellername"],
                        Place = (string)reader ["sellerplace"],
                        Rate = (int)reader ["sellerrate"]
                    });
            }
            return seller;
        }

        public static bool DeleteSeller(int Id) {
            try {
                (new MySqlCommand("DELETE FROM `seller` WHERE id = " + Id, connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Logger.InitLogger();
                Logger.Log.Info("Ошибка удаления поставщика. Причина: " + e);
                return false;
            }
        }

        public static bool EditSeller(Seller seller) {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            try {
                (new MySqlCommand("UPDATE `seller` SET sellername = '" + seller.Name + "'," +
                    " sellerplace = '" + seller.Place + "'," +
                    " sellerrate = '" + seller.Rate + "' " +
                    "WHERE Id = " + seller.Id, connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Logger.InitLogger();
                Logger.Log.Info("Ошибка редактирования поставщика. Причина: " + e);
                return false;
            }
        }



    }
}