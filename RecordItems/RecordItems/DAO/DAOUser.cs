using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;
using System.Diagnostics;

namespace RecordItems.DAO {
    public class DAOUser : DAO {

        public static List<User> GetUsers() {

            List<User> userList = new List<User>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM `user_view`;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    userList.Add(new User() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["name"],
                        Password = (string)reader ["password"],
                        Role_id = (int)reader ["type_id"],
                        Role = (string)reader ["type"]
                    });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка пользователей");

            return userList;
        }


        public static User GetUser(int Id) {
            User user = new User();
            using (var reader = (new MySqlCommand("SELECT * FROM `user_view` WHERE id = " + Id, connection)).ExecuteReader()) {
                while (reader.Read())
                    user = (new User() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["name"],
                        Password = (string)reader ["password"],
                        Role_id = (int)reader ["type_id"],
                        Role = (string)reader ["type"]
                    });
            }
            return user;
        }


        public static bool DeleteUser(int Id) {
            try {
                (new MySqlCommand("DELETE FROM `user` WHERE id = " + Id, connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Logger.InitLogger();
                Logger.Log.Info("Ошибка удаления пользователя. Причина: " + e);
                return false;
            }
        }

        public static bool InsertUser(string name, string password, string type) {

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            try {
                (new MySqlCommand("INSERT INTO `database`.`user`(`name`, `password`, `type`)" +
                    " VALUES ('" + name + "','" + password + "', '" + type + "');", connection))
                    .ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);

                return false;
            }
        }

        public static bool InsertUsReg(User u) {

            string name = u.Name;
            string password = u.Password;
            string type = "2";

            bool ansv = InsertUser(name, password, type);
            return ansv;
        }

        public static bool InsertUsAdd(User u) {

            string name = u.Name;
            string password = u.Password;
            string type = "1";

            bool ansv = InsertUser(name, password, type);
            return ansv;
        }

        public static User GetUserReg(User u) {
            User userList = new User();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM `user` WHERE `name` = '" + u.Name + "' AND `password` = '" + u.Password + "';", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    userList = (new User() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["name"],
                        Password = (string)reader ["password"],
                        Role_id = (int)reader ["type"]
                        //Role = (string)reader ["type"]
                    });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по поиску пользователя");

            return userList;
        }

    }
}