using Npgsql;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Todolist;


namespace ADONetTests
{
    [TestClass]
    public class ADOTests
    {
        DataBase DB = new DataBase();

        [TestMethod]
        public void User_IsValid_Insertion()
        {
            var email= "test@Email";
            var password = "testPass";

            DB.Command = new NpgsqlCommand($"INSERT INTO users(email, password) VALUES ('{email}', '{password}')", DB.Connection);
            DB.Command.ExecuteNonQuery();

            DB.Execute("SELECT email FROM users WHERE email='test@Email' and password='testPass'");

            DB.Reader.Read();
            var str = Convert.ToString(DB.Reader["email"]);
            DB.Reader.Close();

            Assert.AreEqual(email, str, "Invalid user insertion");
            
            DB.Execute("DELETE FROM users WHERE email='test@Email'");
        }

        [TestMethod]
        public void User_Invalid_Insertion()
        {
            var email = "testEmail";
            var password = "testPass";

            DB.Command = new NpgsqlCommand($"INSERT INTO users(email, password) VALUES ('{email+"wrong"}', '{password}')", DB.Connection);
            DB.Command.ExecuteNonQuery();

            DB.Execute("SELECT email FROM users");

            DB.Reader.Read();
            var str = Convert.ToString(DB.Reader["email"]);
            DB.Reader.Close();

            Assert.AreNotEqual(email, str, "Invalid user insertion");

            DB.Execute($"DELETE FROM users WHERE email='{email+"wrong"}'");
        }

        [TestMethod]
        public void Task_IsValid_Insertion()
        {
            var name = "taskTest";
            bool is_done = false;

            int priority = 1;
            int category_id = 4;

            DB.Command = new NpgsqlCommand($"INSERT INTO tasks(name,is_done,priority,category_id) VALUES ('{name}', '{is_done}', '{priority}', '{category_id}')", DB.Connection);
            DB.Command.ExecuteNonQuery();

            DB.Execute("SELECT name FROM tasks WHERE name='taskTest'");

            DB.Reader.Read();
            var str = Convert.ToString(DB.Reader["name"]);
            DB.Reader.Close();

            Assert.AreEqual(name, str, "Invalid task insertion");

            DB.Execute("DELETE FROM tasks WHERE name='taskTest'");
        }
    }
}