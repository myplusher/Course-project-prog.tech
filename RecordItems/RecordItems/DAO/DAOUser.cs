using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;
using RecordItems.Logging;

namespace RecordItems.DAO {
    public class DAOUser : DAO {

        public static List<User> GetUsers() {

            List<User> userList = new List<User>();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM user;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    userList.Add(new User() { Id = (int)reader["id"], Name = (string)reader["name"], Password = (string)reader["password"] });
                }
            }

            Logger.InitLogger();
            Logger.Log.Info("Был вызван метод по созданию списка пользователей");

            return userList;
        }


        public static User GetUser(int Id) {
            User user = new User();
            using (var reader = (new MySqlCommand("SELECT * FROM `user` WHERE id = " + Id, connection)).ExecuteReader()) {
                while (reader.Read())
                    user = (new User() {
                        Id = (int)reader ["id"],
                        Name = (string)reader ["name"],
                        Password = (string)reader ["password"],
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

    }
}