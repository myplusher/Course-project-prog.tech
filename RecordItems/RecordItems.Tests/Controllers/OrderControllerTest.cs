using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordItems.Controllers;
using MySql.Data.MySqlClient;
using RecordItems.DAO;
using RecordItems.Models;

namespace RecordItems.Tests.Controllers {
    [TestClass]
    public class OrderControllerTest {

        [TestMethod]
        public void IndexViewModelNotNull() {
            // Arrange
            OrderController controller = new OrderController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void TestDetailsOrder() {
            Order order = new Order();


            using (var reader = (new MySqlCommand("SELECT * FROM database.order_view WHERE id = 1", DAO.DAO.connection)).ExecuteReader()) {
                while (reader.Read()) {
                    order = (new Order() {
                        Id = (int)reader ["id"],
                        User = (string)reader ["user"],
                        Item = (string)reader ["item"],
                        Count = (int)reader ["count"],
                        Date = (DateTime)reader ["date"]
                    });
                }
                reader.Close();
            }

            string sdate = "2019-10-15";
            Order order_test = new Order();
            order_test = (new Order() {
                Id = 1,
                User = "Дмитриев М.А.",
                Item = "Гвозди",
                Count = 40,
                //Date = (DateTime)sdate;
                Date = Convert.ToDateTime(sdate)
            });



            Assert.AreEqual(order, order_test);

  
        }
    }
}
