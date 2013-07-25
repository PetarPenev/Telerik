//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

//// The script file for the database is located in the project folder.

namespace _09.BooksDatabaseInMySQL
{
    using System;
    using MySql.Data.MySqlClient;

    public class Program
    {
        public static void ListAllBooks(MySqlConnection connection)
        {
            string commandString = @"SELECT b.BookId, t.TitleName, CONCAT(a.FirstName, ' ', a.LastName) AS FullName FROM BOOKS b JOIN Titles t ON b.Titles_TitleId = t.TitleId JOIN Authors a ON b.Authors_AuthorId = a.AuthorId";
            MySqlCommand command = new MySqlCommand(commandString,connection);
            Console.WriteLine();
            MySqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                int bookId = 0;
                string title = string.Empty;
                string name = string.Empty;

                while (reader.Read())
                {
                    bookId = (int)reader["BookId"];
                    title = (string)reader["TitleName"];
                    name = reader["FullName"].ToString();
                    Console.WriteLine("{0}. {1} by {2}", bookId, title, name);
                }
            }
        }

        public static void FindBookByName(MySqlConnection connection)
        {
            Console.WriteLine("Please enter the book name to be searched for.");

            string bookSearchString = Console.ReadLine().Replace("%", "!%")
                .Replace("'", "!'").Replace("\"", "!\"").Replace("_", "!_").ToLower();

            string commandString = string.Format("SELECT b.BookId, t.TitleName, CONCAT(a.FirstName, ' ', a.LastName) AS FullName FROM BOOKS b JOIN Titles t ON b.Titles_TitleId = t.TitleId JOIN Authors a ON b.Authors_AuthorId = a.AuthorId WHERE t.TitleName = '{0}'", bookSearchString);
            MySqlCommand command = new MySqlCommand(commandString, connection);
            MySqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                int bookId = 0;
                string title = string.Empty;
                string name = string.Empty;
                bool bookFound = false;

                while (reader.Read())
                {
                    bookFound = true;
                    bookId = (int)reader["BookId"];
                    title = (string)reader["TitleName"];
                    name = reader["FullName"].ToString();
                    Console.WriteLine("{0}. {1} by {2}", bookId, title, name);
                }

                if (!bookFound)
                {
                    Console.WriteLine("No matching books.");
                }
            }
        }

        public static void InsertBook(MySqlConnection connection, DateTime date, string ISBN, int authId, int titleId)
        {
            string commandString = "INSERT INTO Books (PublishDate, ISBN, Titles_TitleId, Authors_AuthorId) VALUES (@date, @isbn, @authId, @titleId)";
            MySqlCommand command = new MySqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@isbn", ISBN);
            command.Parameters.AddWithValue("@authId", authId);
            command.Parameters.AddWithValue("@titleId", titleId);

            int numberOfInsertions = command.ExecuteNonQuery();
            Console.WriteLine("{0} books inserted.", numberOfInsertions);
        }

        public static void Main()
        {
            MySqlConnection booksConnection = new MySqlConnection(Properties.Settings.Default.DBConnectionString);
            booksConnection.Open();
            ListAllBooks(booksConnection);
            FindBookByName(booksConnection);
            InsertBook(booksConnection, new DateTime(2013, 12, 1), "123456789", 2, 2);
            booksConnection.Close();
        }
    }
}