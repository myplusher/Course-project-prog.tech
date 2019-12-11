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

    }
}