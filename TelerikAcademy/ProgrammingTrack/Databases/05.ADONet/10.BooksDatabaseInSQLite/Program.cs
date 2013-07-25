//// SQLite database is inserted in the bin/debug directory of the homework.

namespace _10.BooksDatabaseInSQLite
{
    using System;
    using System.Data.SQLite;
    using System.IO;

    public class Program
    {
        public static void ListAllBooks(SQLiteConnection connection)
        {
            string commandString = @"SELECT b.BookId, t.TitleName, a.FirstName +  ' ' + a.LastName AS FullName FROM BOOKS b JOIN Titles t ON b.TitleId = t.TitleId JOIN Authors a ON b.AuthorId = a.AuthorId";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            Console.WriteLine();
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                long bookId = 0;
                string title = string.Empty;
                string name = string.Empty;

                while (reader.Read())
                {
                    bookId = (long)reader["BookId"];
                    title = (string)reader["TitleName"];
                    name = reader["FullName"].ToString();
                    Console.WriteLine("{0}. {1} by {2}", bookId, title, name);
                }
            }
        }

        public static void FindBookByName(SQLiteConnection connection)
        {
            Console.WriteLine("Please enter the book name to be searched for.");
            string bookSearchString = Console.ReadLine().Replace("%", "!%")
                .Replace("'", "!'").Replace("\"", "!\"").Replace("_", "!_").ToLower();

            string commandString = string.Format("SELECT b.BookId, t.TitleName, a.FirstName + ' ' + a.LastName AS FullName FROM BOOKS b JOIN Titles t ON b.TitleId = t.TitleId JOIN Authors a ON b.AuthorId = a.AuthorId WHERE t.TitleName = '{0}'", bookSearchString);
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                long bookId = 0;
                string title = string.Empty;
                string name = string.Empty;
                bool bookFound = false;

                while (reader.Read())
                {
                    bookFound = true;
                    bookId = (long)reader["BookId"];
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

        public static void InsertBook(SQLiteConnection connection, DateTime date, string ISBN, int authId, int titleId)
        {
            string commandString = "INSERT INTO Books (Date, ISBN, TitleId, AuthorId) VALUES (@date, @isbn, @authId, @titleId)";
            SQLiteCommand command = new SQLiteCommand(commandString, connection);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@isbn", ISBN);
            command.Parameters.AddWithValue("@authId", authId);
            command.Parameters.AddWithValue("@titleId", titleId);

            int numberOfInsertions = command.ExecuteNonQuery();
            Console.WriteLine("{0} books inserted.", numberOfInsertions);
        }

        public static void Main()
        {
            string databasePath = "Data source = BooksDatabase.db3";
            SQLiteConnection bookConnection = new SQLiteConnection(databasePath);
            bookConnection.Open();
            ListAllBooks(bookConnection);
            FindBookByName(bookConnection);
            InsertBook(bookConnection, new DateTime(2013, 12, 1), "123456789", 2, 2);

            bookConnection.Close();
        }
    }
}
