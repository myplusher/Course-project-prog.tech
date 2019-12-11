using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;

namespace RecordItems.DAO {
    public class DAOOrder : DAO {

        public List<Order> GetOrders() {

            List<Order> orderList = new List<Order>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.order_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    orderList.Add(new Order() { Id = (int)reader["id"], User = (string)reader["user"], Item = (string)reader["item"], Count = (int)reader["count"], Date = (DateTime)reader["date"] });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка заказов");

            return orderList;
        }

    }
}