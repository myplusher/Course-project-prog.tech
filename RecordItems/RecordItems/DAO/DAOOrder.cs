using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;
using System.Diagnostics;

namespace RecordItems.DAO {
    public class DAOOrder : DAO {

        public List<Order> GetOrders() {

            List<Order> orderList = new List<Order>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.order_view;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    orderList.Add(new Order() {
                        Id = (int)reader["id"],
                        User = (string)reader["user"],
                        Item = (string)reader["item"],
                        Count = (int)reader["count"],
                        Date = (DateTime)reader["date"]
                    });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка заказов");

            return orderList;
        }

        public bool InsertOrder(Order or) {

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            try {
                (new MySqlCommand("INSERT INTO `database`.`order`(`user`, `item`, `count`, `date`) VALUES ('" + or.User + "','" + or.Item + "','" + or.Count + "','" + or.Date.ToString("yyyy-MM-dd") + "');", connection))
                    .ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);

                return false;
            }
        }

        public Order GetOrder(int id) {

            Order order = new Order();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM database.order_view WHERE id = " + id, connection)).ExecuteReader()) {
                while (reader.Read()) {
                    order = (new Order() {
                        Id = (int)reader ["id"],
                        User = (string)reader ["user"],
                        Item = (string)reader ["item"],
                        Count = (int)reader ["count"],
                        Date = (DateTime)reader ["date"]
                    });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка заказов");

            return order;
        }
    }
}