using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RecordItems.Models;

namespace RecordItems.DAO {
    public class DAOUser : DAO {

        public List<User> GetUsers() {

            List<User> userList = new List<User>();
            connection.Open();

            using (var reader = (new MySqlCommand("SELECT * FROM user;", connection)).ExecuteReader()) {
                while (reader.Read()) {
                    userList.Add(new User() { Id = (int)reader["id"], Name = (string)reader["name"], Password = (string)reader["password"] });
                }
            }

            return userList;
        }

    }
}