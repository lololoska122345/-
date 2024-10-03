using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace UnitTestProject1
{
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestInitialize]
            public void Setup()
            {
                string query = "DELETE FROM test";
                БД.connection.Open();
                SqlCommand cmd = new SqlCommand(query, БД.connection);
                int i = cmd.ExecuteNonQuery();
                БД.connection.Close();
            }
            [TestCleanup]
            public void CleanUp()
            {
                БД.connection.Close();
            }
            [TestMethod]
            public void TestAdd()
            {
                string[,] a = new string[,] {
                {"1", "Очень странно." },
                {"2", "Будем разбираться!" },
                {"3", "Проще простого!" },
               
            };
                БД.connection.Open();
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    string query = "INSERT INTO test (commentID, message) VALUES (@commentID, @message)";
                    using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                    {
                        cmd.Parameters.AddWithValue("@commentID", a[i, 0]);
                        cmd.Parameters.AddWithValue("@message", a[i, 1]);
                        cmd.ExecuteNonQuery();
                    }
                }
                string query1 = "SELECT COUNT(*) FROM test";
                SqlCommand cmd1 = new SqlCommand(query1, БД.connection);
                int result1 = (int)cmd1.ExecuteScalar();
                Assert.AreEqual(3, result1);
                БД.connection.Close();
            }
            [TestMethod]
            public void TestEdit()
            {
                БД.connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM test WHERE commentID = @commentID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, БД.connection))
                {
                    checkCmd.Parameters.AddWithValue("@commentID", "1");
                    int recordExists = (int)checkCmd.ExecuteScalar();
                    if (recordExists > 0)
                    {
                        string query = "UPDATE test SET message = @message WHERE commentID = @commentID";
                        using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                        {
                            cmd.Parameters.AddWithValue("@commentID", "1");
                            cmd.Parameters.AddWithValue("@message", "Кошмар");
                            int rowsAffected = cmd.ExecuteNonQuery();
                            Assert.AreEqual(1, rowsAffected, "Запись не была обновлена");
                            string query1 = "SELECT password FROM test WHERE commentID = @commentID";
                            using (SqlCommand cmd1 = new SqlCommand(query1, БД.connection))
                            {
                                cmd1.Parameters.AddWithValue("@commentID", "1");
                                string result1 = (string)cmd1.ExecuteScalar();
                                Assert.AreEqual("Кошмар", result1, "Пароль не был обновлен правильно");
                            }
                        }
                    }
                }
                БД.connection.Close();
            }


            [TestMethod]
            public void TestDelete()
            {
                БД.connection.Open();
                string query = "DELETE FROM test WHERE commentID = @commentID";
                using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                {
                    cmd.Parameters.AddWithValue("@commentID", "2");
                    cmd.ExecuteNonQuery();
                }
                string query1 = "SELECT COUNT(*) FROM test WHERE commentID = @commentID";
                using (SqlCommand cmd1 = new SqlCommand(query1, БД.connection))
                {
                    cmd1.Parameters.AddWithValue("@commentID", "2");
                    cmd1.ExecuteNonQuery();
                    int result1 = (int)cmd1.ExecuteScalar();
                    Assert.AreEqual(0, result1);
                }
                БД.connection.Close();
            }
            [TestMethod]
            public void TestDuplicate()
            {
                БД.connection.Open();
                string query = "INSERT INTO test (commentID, message) VALUES (@commentID, @message)";
                using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                {
                    cmd.Parameters.AddWithValue("@commentID", "3");
                    cmd.Parameters.AddWithValue("@message", "message3");
                    cmd.ExecuteNonQuery();
                }
                bool insertFailed = false;
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                    {
                        cmd.Parameters.AddWithValue("@commentID", "3");
                        cmd.Parameters.AddWithValue("@message", "Блин, ужас");
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException)
                {
                    insertFailed = true;
                }
                Assert.IsTrue(insertFailed, "Дублирующая запись была успешно добавлена, что не допускается.");
                БД.connection.Close();
            }
            [TestMethod]
            public void TestEmpty()
            {
                БД.connection.Open();

                string query = "INSERT INTO test (commentID, message) VALUES (@commentID, @message)";
                bool insertFailed = false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, БД.connection))
                    {
                        cmd.Parameters.AddWithValue("@commentID", null);
                        cmd.Parameters.AddWithValue("@message", null);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException)
                {
                    insertFailed = true;
                }

                Assert.IsTrue(insertFailed, "Запись с пустыми полями была успешно добавлена, что не допускается.");

                БД.connection.Close();
            }
        }
    }


}
