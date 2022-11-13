using Npgsql;
using System.Configuration;
using System.Text;

using System.Data;

namespace Todolist
{
    public class DataBase
    {
        public NpgsqlConnection Connection { get; set; }
        public NpgsqlCommand Command { get; set; }
        public NpgsqlDataReader Reader { get; set; }
        public DataBase()
        {
            string connectionString = "Server=localhost ; port=5432 ; user id=postgres ; password=123 ; database=todo ;";
            Connection = new NpgsqlConnection(connectionString);
            Reader = null;
            Connect();
        }
        ~DataBase()
        {
            Disconnect();
        }
        private void Connect()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Disconnect()
        {
            if (Connection == null)
            {
                return;
            }

            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public void Execute(string query)
        {
            Command = new NpgsqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
        }

        private List<string> get_cols(string table_name)
        {
            Execute($"SELECT column_name FROM information_schema.columns WHERE table_name = '{table_name}'");

            var lst = new List<string>();

            while (Reader.Read())
            {
                lst.Add(Convert.ToString(Reader["column_name"]));
            }

            Reader.Close();

            return lst;
        }

        private List<string> get_tables()
        {
            Execute($"SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' AND table_type='BASE TABLE' ORDER BY table_name ");

            var lst = new List<string>();

            while (Reader.Read())
            {
                lst.Add(Convert.ToString(Reader["table_name"]));
            }

            Reader.Close();

            return lst;
        }

        public void Print()
        {
            var tables = get_tables();

            foreach (var table in tables)
            {
                var cols = get_cols(table);

                var query = $"SELECT * FROM {table}";

                Execute(query);

                Console.WriteLine($"\nTable \"{table}\" :");

                Console.WriteLine(String.Join("\t\t", cols.ToArray()));
                Console.WriteLine("------------------------------------------------------------------------------------");

                while (Reader.Read())
                {
                    var row = "";

                    foreach (var column in cols)
                    {
                        row += Reader[column] + "\t\t";
                    }

                    Console.WriteLine(row);
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
                Reader.Close();
            }
        }

        public static string GenerateRandomAlphabetString(int length)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwyxz";
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rnd.Next(allowedChars.Length)];
            }

            return new string(chars);
        }

        public static string GenerateRandomEmail()
        {
            string[] email = { "gmail.com", "lnu.edu.ua", "ukr.net", "aol.com", "yahoo.com" };
            var rand = new Random();
            return string.Format("{0}@{1}", GenerateRandomAlphabetString(10), email[rand.Next(0, 4)]);
        }

        public void UsersInsertion()
        {
            var email = GenerateRandomEmail();
            var password = GenerateRandomAlphabetString(8);
            try
            {
                Command = new NpgsqlCommand($"INSERT INTO users(email, password) VALUES ('{email}', '{password}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Given wrong data");
            }
        }

        public void TasksInsertion()
        {
            var rand = new Random();

            var name = GenerateRandomAlphabetString(7);
            bool is_done = Convert.ToBoolean(rand.Next(0, 2));

            int priority = rand.Next(0, 2);
            int category_id = rand.Next(1, 5);


            Command = new NpgsqlCommand($"INSERT INTO tasks(name,is_done,priority,category_id) VALUES ('{char.ToUpper(name[0]) + name.Substring(1)}', '{is_done}', '{priority}', '{category_id}')", Connection);
            Command.ExecuteNonQuery();

        }
    }
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Enter 'Print' to print tables");
            Console.WriteLine("Enter 'users' to insert \"users\" table");
            Console.WriteLine("Enter 'tasks' to insert \"tasks\" table");
            Console.WriteLine("Enter 'Exit' to exit");

            DataBase todo_db = new DataBase();

            while (true)
            {
                Console.WriteLine("\nCommand:");
                var input = Console.ReadLine();

                if (input.ToLower() == "print")
                {
                    todo_db.Print();
                    continue;
                }

                if (input.ToLower() == "users")
                {
                    todo_db.UsersInsertion();
                    todo_db.Print();
                    continue;
                }

                if (input.ToLower() == "tasks")
                {
                    todo_db.TasksInsertion();
                    todo_db.Print();
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    break;
                }
            }
        }
    }
}
