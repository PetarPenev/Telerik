//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

namespace _08.EscapeDangerousSymbols
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the product name to be searched for.");
            string productSearchString = Console.ReadLine().Replace("%", "!%")
                .Replace("'", "!'").Replace("\"", "!\"").Replace("_", "!_").ToLower();

            SqlConnection northwindConnection = new SqlConnection(Properties.Settings.Default.DBConnectionString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand(string.Format(
                @"SELECT ProductName FROM Products WHERE LOWER(ProductName) LIKE '%{0}%' ESCAPE '!'", productSearchString), northwindConnection);

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("The found products are:");
                bool itemIsFound = false;

                while (reader.Read())
                {
                    string name = (string)reader["ProductName"];
                    Console.WriteLine(name);
                    itemIsFound = true;
                }

                if (!itemIsFound)
                {
                    Console.WriteLine("No matching products.");
                }
            }

            northwindConnection.Close();
        }
    }
}