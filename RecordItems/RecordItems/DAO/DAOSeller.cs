using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;

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

            return sellerList;
        }

    }
}