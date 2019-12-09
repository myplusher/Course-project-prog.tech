using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;

namespace RecordItems.DAO {
    public class DAOSeller : DAO {

        public List<Seller> GetSellers() {

            List<Seller> sellerList = new List<Seller>();
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

    }
}