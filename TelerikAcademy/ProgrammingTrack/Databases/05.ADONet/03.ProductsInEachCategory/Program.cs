//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

namespace _03.ProductsInEachCategory
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            SqlConnection northwindConnection = new SqlConnection(Properties.Settings.Default.DBConnectionString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON c.CategoryID = p.CategoryID",
                northwindConnection);

            SqlDataReader reader = command.ExecuteReader();
            string currentCategory = string.Empty;
            StringBuilder categoryString = new StringBuilder();

            using (reader)
            {
                while (reader.Read())
                {
                    string intermediateCategory = (string)reader["CategoryName"];
                    if (intermediateCategory != currentCategory)
                    {
                        Console.Write(categoryString.ToString().TrimEnd(new char[] { ' ', ',' }));

                        if (currentCategory != string.Empty)
                        {
                            Console.WriteLine();
                        }

                        currentCategory = intermediateCategory;
                        categoryString.Clear();
                        categoryString.Append(currentCategory + " -> ");
                    }

                    string currentProduct = (string)reader["ProductName"];
                    categoryString.Append(currentProduct + ", ");
                }
            }

            northwindConnection.Close();
        }
    }
}